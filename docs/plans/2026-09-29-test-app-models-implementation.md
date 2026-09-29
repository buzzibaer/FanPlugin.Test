# Test App Model Support Implementation Plan

> **For Claude:** REQUIRED SUB-SKILL: Use superpowers:executing-plans to implement this plan task-by-task.

**Goal:** Update FanPlugin.Test to exercise the current Fan, FanV3, and Fan20320 implementations with separate model panels and editable per-model network settings.

**Architecture:** Keep the existing V2/V3 panels and actions, add a Fan20320-only playback panel, and add IP/port/timeout inputs to each panel. Cache one wrapper instance per panel; make Fan20320 configuration changes invalidate its persistent session so the next operation uses current settings.

**Tech Stack:** C# 7.3, .NET Framework 4.7.2, Windows Forms, MSTest in the adjacent FanPlugin.Wrapper repository.

---

### Task 1: Make Fan20320 settings changes reset its session

**Files (Wrapper repository `E:\OpenCodeProjects\3dcircle\FanPlugin.Wrapper`):**
- Modify: `Fan20320.cs`
- Test: `tests/FanPlugin.Wrapper.Tests/Fan20320Tests.cs`

**Step 1: Add a failing regression test**

Use the existing loopback test-server helpers or add a helper to verify that changing a connected instance's endpoint configuration closes the active session. Test that setting an unchanged value leaves the session intact, while changing `ServerPort` closes it. Assert that the next playback request opens a new session and sends the startup handshake there.

**Step 2: Run the targeted test**

Run: `dotnet test tests/FanPlugin.Wrapper.Tests/FanPlugin.Wrapper.Tests.csproj --no-restore --filter Fan20320Tests`

Expected: the new invalidation test fails before implementation.

**Step 3: Implement invalidating configuration properties**

Replace the four auto-properties in `Fan20320` with backing fields. In each setter, compare using the property's natural equality (ordinal for IP strings); when the value changes, update it and call the existing `CloseSession()`. Preserve the same defaults and COM-visible property names.

**Step 4: Verify wrapper tests/build**

Run the targeted test and then:

```powershell
dotnet test tests/FanPlugin.Wrapper.Tests/FanPlugin.Wrapper.Tests.csproj --no-restore
dotnet build FanPlugin.Wrapper.csproj -c Release --no-restore
```

Expected: all tests pass and Release build has 0 warnings/errors.

**Step 5: Commit wrapper change**

```bash
git add Fan20320.cs tests/FanPlugin.Wrapper.Tests/Fan20320Tests.cs
git commit -m "Reset Fan20320 session when settings change"
```

### Task 2: Add model-specific endpoint settings and Fan20320 controls

**Files (FanPlugin.Test repository):**
- Modify: `Form1.Designer.cs`
- Modify: `Form1.cs`

**Step 1: Implement reusable per-model configuration controls**

Add IP, port, connect-timeout, and socket-timeout text inputs to the existing Fan and FanV3 groups with defaults:

```text
Fan:     192.168.4.1, 5233, 3000, 3000
FanV3:   192.168.4.1, 5233, 3000, 3000
Fan20320:192.168.4.1, 20320, 3000, 3000
```

Add a third distinct Fan20320 group with a video ID input, `Play Video` button, and short note that files are resolved by six-digit filename (for example, ID 5 selects `000005.bin`) and the class obtains its file list automatically. Do not add loop, power, next/previous or upload controls to this group.

**Step 2: Cache and configure implementation instances**

Keep one `Fan`, one `FanV3`, and one `Fan20320` field on `Form1`. Create an instance lazily for each panel, assign that panel's current IP/port/timeouts before each call, and reuse the instance. Fan20320 property setters from Task 1 reset a session only when a setting actually changes. Existing V2/V3 buttons continue invoking the same wrapper methods they invoke today.

**Step 3: Route results and validation to the existing log**

For each new input, parse port/timeouts as positive integers and display a clear input error in `tbLog` without contacting the fan when invalid. Catch unexpected UI event exceptions and display their messages in the log. Keep wrapper-returned network errors visible verbatim.

**Step 4: Build the test app**

Run:

```powershell
dotnet build FanPlugin.sln -c Debug
dotnet build FanPlugin.sln -c Release
```

Expected: both builds succeed without errors. Review the three panels in the form designer/runtime and verify each event handler applies only its panel's settings and model.

**Step 5: Commit test-app changes**

```bash
git add Form1.cs Form1.Designer.cs
git commit -m "Add Fan20320 to standalone tester"
```

### Task 3: Document the standalone tester model selection

**Files (FanPlugin.Test repository):**
- Modify: `README.md`

**Step 1: Add concise instructions**

Document that the tester has separate Fan, FanV3, and Fan20320 panels; endpoint and timeout values are editable per panel; Fan20320 plays existing six-digit `.bin` filenames by ID and does not upload files; and its hardware has not yet been physically verified.

**Step 2: Verify the README change**

Run: `git diff --check`

Expected: no whitespace errors. Confirm the README does not describe unsupported Fan20320 controls.

**Step 3: Commit documentation**

```bash
git add README.md
git commit -m "Document standalone tester model support"
```

### Task 4: Final cross-repository verification

**Files:** No additional source files.

**Step 1: Run wrapper verification**

Run full wrapper tests and Release build from the FanPlugin.Wrapper repository.

**Step 2: Run test-app verification**

Run Debug and Release solution builds from FanPlugin.Test.

**Step 3: Check both repositories**

Run `git status -sb` in each repository and review all commits and diffs before proposing integration.

Expected: clean worktrees; Fan20320 tests prove changed endpoint settings cause a new handshake/session; test app builds and presents three model-specific areas.
