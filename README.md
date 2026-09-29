# FanPlugin.Test

This is a standalone test programm for your 3 holo fan.

You can use this without any Virtual Pinball Software integration just to test if everything works.

The fully integrated plugin is here >> https://github.com/buzzibaer/FanPlugin.Wrapper

Config of the Fan can be found here >> https://github.com/buzzibaer/FanPlugin.Wrapper#configuring-the-fan-to-static-ip

## Versions of the Fan
There more than one version of the Fan out there.
They seam to be very similar, but...:)

Just try out what kind of fan works for you.
The tester has separate panels for Fan, FanV3, and Fan20320. Each panel has editable endpoint and timeout fields for that model.

Controls differ by protocol, so Fan20320 only exposes playback. It plays `.bin` files that are already stored on the fan, selected by ID: for example, ID `5` plays `000005.bin`. The tester obtains the file list automatically when it first connects and caches it for that TCP session; changing endpoint or timeout settings resets the connection, and the next playback reconnects and fetches the list again. The tester does not upload files. Fan20320 has not been physically verified.

## Selecting a video file
![explain pic](https://github.com/buzzibaer/FanPlugin.Test/blob/main/doc/2023-11-25%2015_56_23-Fan%20Test%20App.png)

Type in a video file ID and push the Button <Set Video on Fan>
