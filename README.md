# Emik.Rubbish

[![NuGet package](https://img.shields.io/nuget/v/Emik.Rubbish.svg?color=50fa7b&logo=NuGet&style=for-the-badge)](https://www.nuget.org/packages/Emik.Rubbish)
[![License](https://img.shields.io/github/license/Emik03/Emik.Rubbish.svg?color=6272a4&style=for-the-badge)](https://github.com/Emik03/Emik.Rubbish/blob/main/LICENSE)

Cross-platform library to send files to the recycle bin. Supports all major desktop platforms. (Windows, Mac, and Linux)

This project has a dependency to [Emik.Morsels](https://github.com/Emik03/Emik.Morsels), if you are building this project, refer to its [README](https://github.com/Emik03/Emik.Morsels/blob/main/README.md) first.

---

- [API](#api)
- [Contribute](#contribute)
- [License](#license)

---

## API

- [`Emik.Rubbish.Move(string)`](https://github.com/Emik03/Emik.Rubbish/blob/master/Documentation/Rubbish.Move(string).md): Moves the file or directory to the recycling bin.
- [`Emik.Rubbish.MoveAsync(string, CancellationToken)`](https://github.com/Emik03/Emik.Rubbish/blob/master/Documentation/Rubbish.MoveAsync(string%2CCancellationToken).md): Moves the file or directory to the recycling bin asynchronously.

## Contribute

Issues and pull requests are welcome to help this repository be the best it can be.

## License

This repository falls under the [MPL-2 license](https://www.mozilla.org/en-US/MPL/2.0/).
