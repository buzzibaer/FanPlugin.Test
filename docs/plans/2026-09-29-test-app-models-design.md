# Test App Model Support Design

## Goal

Update the standalone Windows Forms tester to exercise Fan, FanV3, and Fan20320 implementations from the adjacent Wrapper project.

## UI Structure

Keep three distinct model-specific panels rather than combining all commands into a shared control set. Preserve existing Fan and FanV3 test actions. Add a Fan20320 panel with video ID selection and playback only; do not show commands that Fan20320 does not implement.

Each model panel has its own IP, port, connect-timeout, and socket-timeout fields initialized from that implementation's defaults. Results and network errors continue to appear in the existing log.

## Session Lifecycle

Fan20320 uses a persistent TCP session and caches the SD file list, so the form retains one Fan20320 instance instead of constructing a new instance for each click. Changes to its endpoint or timeout values must reset the previous session so the next command uses the changed configuration. This requires a small corresponding wrapper update if the current API cannot safely invalidate an established session.

Fan/FanV3 keep their existing short-command behavior and available model-specific controls.

## Dependencies and Validation

The tester continues to use the adjacent `FanPlugin.Wrapper.csproj` project reference. Validate by building the solution in Debug and Release configurations and manually inspecting each panel's model-specific action wiring. No physical fan is available for hardware validation.
