# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.0.0] - 2018-12-18
### Changed
- Weighted edges now use the double type for weights instead of int.
- A generic vertex type is now used for edges and graphs.

## [1.1.0] - 2018-12-17
### Added
- Added the GraphCalculations static class.
- Added the IsCompleteGraph property to graph classes.

### Changed
- An InvalidOperationException is now thrown when an attempt is made to add an
  edge to a complete graph.

### Fixed
-  XML documentation comment fixes.

## [1.0.0] - 2018-12-14
### Added
- Initial code.

[Unreleased]: https://github.com/Xyaneon/Xyaneon.ComputerScience.GraphTheory/compare/v2.0.0...HEAD
[1.1.0]: https://github.com/Xyaneon/Xyaneon.ComputerScience.GraphTheory/compare/v1.1.0...v2.0.0
[1.1.0]: https://github.com/Xyaneon/Xyaneon.ComputerScience.GraphTheory/compare/v1.0.0...v1.1.0
[1.0.0]: https://github.com/Xyaneon/Xyaneon.ComputerScience.GraphTheory/compare/59c07192b4dc956019348bf39968a22521e2616c...v1.0.0