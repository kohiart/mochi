# Changelog

Documentation of all notable changes to the **evmone** project.

The format is based on [Keep a Changelog],
and this project adheres to [Semantic Versioning].

## [0.2.0] - 2019-09-24

This release of evmone is binary compatible with 0.1 and delivers big performance improvements
– both code preprocessing and execution is **~66%** faster (needs ~40% less time).

### Added
- **evm-test** – the testing tool for [EVMC]-compatible EVM implementations.
  [#85](https://github.com/ethereum/evmone/pull/85)
- **evmone-fuzzer** – the testing tool that fuzzes evmone execution against [aleth-interpreter][Aleth] execution.
  Any other [EVMC]-compatible EVM implementation can be added easily.
  [#162](https://github.com/ethereum/evmone/pull/162)
  [#184](https://github.com/ethereum/evmone/pull/184)
- **evmone-standalone** – single static library that bundles evmone with all its static library dependencies 
  (available on Linux, but support can be extended to other platforms).
  [#95](https://github.com/ethereum/evmone/pull/95)
- The **evmone-bench** tool has learned how to benchmark external [EVMC]-compatible EVMs.
  [#111](https://github.com/ethereum/evmone/pull/111)
- The **evmone-bench** tool sorts test cases by file names and allows organizing them in subfolders.
  [#150](https://github.com/ethereum/evmone/pull/150)
- The docker image [ethereum/evmone](https://hub.docker.com/r/ethereum/evmone)
  with evmone and modified geth is available on Docker Hub.
  [#127](https://github.com/ethereum/evmone/pull/127)


### Changed

#### Optimizations

- Instead of checking basic block preconditions (base gas cost, stack requirements) in the dispatch loop, 
  this is now done in the special "BEGINBLOCK" instruction — execution time reduction **-2–8%**.
  [#74](https://github.com/ethereum/evmone/pull/74)
- New EVM stack implementation has replaced naïve usage of `std::vector<intx::uint256>` — **-8–16%**.
  [#79](https://github.com/ethereum/evmone/pull/79)
- Improvements to interpreter's dispatch loop — **-4–9%**.
  [#107](https://github.com/ethereum/evmone/pull/107)
- Optimization of the JUMPDEST map — up to **-34%**.
  [#80](https://github.com/ethereum/evmone/pull/80)
- Optimizations to code preprocessing / analysis.
  [#121](https://github.com/ethereum/evmone/pull/121)
  [#125](https://github.com/ethereum/evmone/pull/125)
  [#153](https://github.com/ethereum/evmone/pull/153)
  [#168](https://github.com/ethereum/evmone/pull/168)
  [#178](https://github.com/ethereum/evmone/pull/178)
- Push instructions with values up to 8 bytes (PUSH1–PUSH8)
  are now handled much more efficiently — up to **-9%**.
  [#122](https://github.com/ethereum/evmone/pull/122)
- Pointer to next instruction is now obtained in instruction implementations 
  (instead of the dispatch loop) and is kept in CPU registers only — **-3–7%**.
  [#133](https://github.com/ethereum/evmone/pull/133)
- The run-time information about basic blocks has been compressed.
  [#139](https://github.com/ethereum/evmone/pull/139)
  [#144](https://github.com/ethereum/evmone/pull/144)
  
#### Other changes

- The DUP, SWAP, LOG and CALL instructions are now implemented by individual functions (template instances)
  instead of a parametrized function handling each family of instructions.
  [#126](https://github.com/ethereum/evmone/pull/126)
  [#159](https://github.com/ethereum/evmone/pull/159)
- [EVMC] upgraded to version [6.3.1](https://github.com/ethereum/evmc/releases/tag/v6.3.1).
  [#129](https://github.com/ethereum/evmone/pull/129)
  [#77](https://github.com/ethereum/evmone/pull/77)
  [#96](https://github.com/ethereum/evmone/pull/96)
- [intx] upgraded to version [0.4.0](https://github.com/chfast/intx/releases/tag/v0.4.0).
  [#131](https://github.com/ethereum/evmone/pull/131)
- The ability to provide custom opcode table for code preprocessing has been dropped.
  [#167](https://github.com/ethereum/evmone/pull/167)


### Fixed

- The gas calculation for blocks containing an undefined instruction has been fixed.
  This bug could not cause consensus issue because a block with an undefined instruction terminates 
  with an exception despite incorrect gas checking.
  However, execution might have ended with a confusing error code.
  [#93](https://github.com/ethereum/evmone/pull/93)
- Fix for LOG being emitted after _out-of-gas_ exception.
  [#120](https://github.com/ethereum/evmone/pull/120)


## [0.1.1] - 2019-09-11
### Changed
- [EVMC] upgraded to version 6.3.1 (still ABI-compatible with evmone 0.1.0).
  [#171](https://github.com/ethereum/evmone/pull/171)
- Changes to the **evmone-bench** tool backported from 0.2. 
  This allows better performance comparison between 0.1 and 0.2 as both versions
  can run the same set of benchmarks.
  [#172](https://github.com/ethereum/evmone/pull/172)


## [0.1.0] - 2019-06-19

The first release of the evmone project. 
It delivers fully-compatible and high-speed EVM implementation.

### Added
- Support for all current EVM revisions up to Petersburg.
- Exposes [EVMC] 6 ABI.
- The [intx 0.2.0](https://github.com/chfast/intx/releases/tag/v0.2.0) library is used for 256-bit precision arithmetic. 


[0.2.0]: https://github.com/ethereum/evmone/releases/tag/v0.2.0
[0.1.1]: https://github.com/ethereum/evmone/releases/tag/v0.1.1
[0.1.0]: https://github.com/ethereum/evmone/releases/tag/v0.1.0

[Aleth]: https://github.com/ethereum/aleth
[EVMC]: https://github.com/ethereum/evmc
[intx]: https://github.com/chfast/intx
[Keep a Changelog]: https://keepachangelog.com/en/1.0.0/
[Semantic Versioning]: https://semver.org
