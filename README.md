# Yu-Gi-Oh! Tag Force Randomizer GUI

This is a GUI frontend & build automation for [TFRandomizer](https://github.com/xan1242/TFRandomizer).

With this utility, you can easily randomize deck recipes and the card shop boxes in Tag Force.

## Compatibility

Currently this tool only supports Tag Force 3. More games are to come as their parameters are discovered and recipe loader code is written.

## Usage

1. Perform the initial setup with the button at the bottom of the window using a supported game (at the time of writing it's only Tag Force 3 ULES-01183)

2. Adjust your parameters

3. Click randomize

4. Save the new ISO image somewhere

5. Load the ISO in your emulator of choice (real PSP hardware untested, TODO)



To see the effects of the recipe randomizer, you must start a new game. The recipe randomization will not work on a saved game.





## Requirements

- [.NET Desktop Runtime 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) for your platform (most likely x64)

- [Visual C++ Redistributable 2015 - 2022](https://aka.ms/vs/17/release/vc_redist.x86.exe)

- Disk space for at least 3x your ISO size (original data + tool cached data + result data)

## TODO

- Support for other games

- Lots and lots of testing

- More randomization features (this is entirely dependant on TFRandomizer)
