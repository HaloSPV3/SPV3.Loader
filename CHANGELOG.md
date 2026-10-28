## [2.3.0-alpha.5](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.3.0-alpha.4...v2.3.0-alpha.5) (2026-10-28)

### Bug Fixes

* **deps:** do not upgrade System.Text.Json in .NET 6 builds ([ddb741f](https://github.com/HaloSPV3/SPV3.Loader/commit/ddb741fb3061844dce5ae60d581dfc261c55c9b2))

## [2.3.0-alpha.4](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.3.0-alpha.3...v2.3.0-alpha.4) (2026-10-28)

### Features

* **Configuration:** add `AllowPreReleaseUpdates` (default: false) to check for SPV3.Loader pre-release updates; fix "Upstream version" button opening wrong URL ([d918213](https://github.com/HaloSPV3/SPV3.Loader/commit/d9182134b284756cb7d804aa757c11d714240567))

### Bug Fixes

* add fallback font families for Wine users ([f6eff1c](https://github.com/HaloSPV3/SPV3.Loader/commit/f6eff1ce4522ab3ff805e88754fb9acfb2f537d0))
* change assembly name (and filename) back to `SPV3` ([903ac06](https://github.com/HaloSPV3/SPV3.Loader/commit/903ac06ad4d24f2c96f05e609721ba3fdf041592))
* **Compile:** adjust file/console logging for consistency ([1742f3a](https://github.com/HaloSPV3/SPV3.Loader/commit/1742f3af2cb6a38fe90c02269a1fba5d86a90eb9))
* **Configuration:** log Loader Configuration `Load()` errors to console, too ([2cd2bad](https://github.com/HaloSPV3/SPV3.Loader/commit/2cd2bada68e9e8b6740d0afdc2e1cbe2540590c6))
* **Configuration:** log warning to console when OpenSauce is not installed properly ([47c1ece](https://github.com/HaloSPV3/SPV3.Loader/commit/47c1ece731cb31708468d2af17b08f142f3048df))
* **deps:** bump HXE to `aed3780` ([54838eb](https://github.com/HaloSPV3/SPV3.Loader/commit/54838ebc2ec11b058d489e2a76d07f680e5c8039))
* **deps:** upgrade HXE to 3.0.1 ([99fac5d](https://github.com/HaloSPV3/SPV3.Loader/commit/99fac5d910483599e4af26a7166d833bee1f0b90))
* **deps:** upgrade HXE to 3.1.2 ([ca24ddb](https://github.com/HaloSPV3/SPV3.Loader/commit/ca24ddb9f7e29b4699de35c4bdf5809b2c922309))
* **deps:** upgrade HXE to v3.1.0 ([6523414](https://github.com/HaloSPV3/SPV3.Loader/commit/65234149b74bd34ced242a875aa3b1f8de0d72c1))
* **deps:** upgrade MahApps.Metro to v2.4.11 ([8fd4d9f](https://github.com/HaloSPV3/SPV3.Loader/commit/8fd4d9fac5400babe297909df7061fb2b57de157))
* **deps:** upgrade System.Text.Json to 10.0.12 ([52a5113](https://github.com/HaloSPV3/SPV3.Loader/commit/52a511344d081e4fd678e259427d03542a791fd8))
* **deps:** upgrade System.Text.Json to v10.0.13 ([d40d0e5](https://github.com/HaloSPV3/SPV3.Loader/commit/d40d0e5dcb1b6d3b66619410af0a0d6d633bb276))
* **Install:** adjust file/console logging for consistency ([d13aae9](https://github.com/HaloSPV3/SPV3.Loader/commit/d13aae911845af26485c90a8c5a8e0e77822bc90))
* **Install:** do not overwrite the installer's current log file in `Install.Initialise()` ([7fd92a3](https://github.com/HaloSPV3/SPV3.Loader/commit/7fd92a35856d8f8304e36f36d9ebaceebd1d5320))
* **Main:** rotate exception.log files to exception.2.log and greater ([9c15426](https://github.com/HaloSPV3/SPV3.Loader/commit/9c15426496468f2c88cac7ea12995ded4813272f))
* rotate exception.log so old logs are not immediately lost ([a1502ff](https://github.com/HaloSPV3/SPV3.Loader/commit/a1502ff048d4474f86b7bcfad336236b8d69bb79))
* **Version:** change Changelog URL to CHANGELOG.md on `main` branch ([fa4f134](https://github.com/HaloSPV3/SPV3.Loader/commit/fa4f134c80e81005b9cc0fcf2781779b43ffe5e7))
* **Version:** use current GitVersionInformation.FullSemVer when opening release-tag comparison (GitHub git log) ([2439643](https://github.com/HaloSPV3/SPV3.Loader/commit/2439643873c6ea2c06441af9332c006559b22279))

## [2.3.0-alpha.3](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.3.0-alpha.2...v2.3.0-alpha.3) (2026-09-04)

### Features

* **deps:** support .NET Framework 4.8 for legacy clients e.g. Windows 7/8/8.1/ and/or 32-bit x86 CPUs ([9b4232b](https://github.com/HaloSPV3/SPV3.Loader/commit/9b4232b1f47f175ed407825e08f309a696cc86f3))

### Bug Fixes

* **Configuration:** prevent `InvalidOperationException` when checking `GBuffer_CheckBox.IsChecked` ([ac1f7b7](https://github.com/HaloSPV3/SPV3.Loader/commit/ac1f7b788d5111c95d2b109f200f47ccb9e44978))
* **deps:** upgrade System.Text.Json in .NET Framework releases for feature parity e.g. source generation ([57cf3c8](https://github.com/HaloSPV3/SPV3.Loader/commit/57cf3c82d97c30329747a495aa4b5bac74c62892))
* **Version:** init Address, Content, Version ([80bcaf5](https://github.com/HaloSPV3/SPV3.Loader/commit/80bcaf57cbd858ef6efeef199a80621ee7eceb8e))
* **Version:** use code-generated assembly version; change version URL to GitHub Release URL ([4af5cd4](https://github.com/HaloSPV3/SPV3.Loader/commit/4af5cd4816a02117413407acc7a5dbc14ea7dff2))

### Performance Improvements

* **deps:** prefer running as native Arm64 instead of emulated x64 when applicable ([1c3e146](https://github.com/HaloSPV3/SPV3.Loader/commit/1c3e14607d05a0d81a67f44742f81ac066e1b8c8))

### Reverts

* **deps:** drop support for net462 (.NET Framework 4.6.2), net480 (.NET Framework 4.8) ([5547773](https://github.com/HaloSPV3/SPV3.Loader/commit/5547773d81dc15dd4580a8fb4ddf5860176a8ae7))

## [2.3.0-alpha.2](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.3.0-alpha.1...v2.3.0-alpha.2) (2026-07-24)

### Bug Fixes

* **Configuration:** prevent possible `InvalidOperationException` in `AdaptiveHDRChanged` ([7454ea0](https://github.com/HaloSPV3/SPV3.Loader/commit/7454ea01fb33c1bc374342ae6caaebd87047caf2))
* **Install:** add detailed Exception when the install path lacks a path root i.e. drive/volume letter ([a0f17da](https://github.com/HaloSPV3/SPV3.Loader/commit/a0f17da2263dfd6a6fa79fd3417fc72c12671007))
* **Main:** change Assets (update.hxe) address to https://raw.githubusercontent.com/HaloSPV3/HCE/meta/update.hxe ([c869e93](https://github.com/HaloSPV3/SPV3.Loader/commit/c869e9329d15fa42128470f4bc4dd7b6b336ab51))
* **Main:** initialize MainError.Content to `string.Empty` ([3419e29](https://github.com/HaloSPV3/SPV3.Loader/commit/3419e29613ce775dbc52ad85a48dd6d58211aacc))
* **News:** add default "Fail" message when News fails to fetch or parse ([f2cb2b1](https://github.com/HaloSPV3/SPV3.Loader/commit/f2cb2b119e41d3977d7bc9b01fc0fbb5966d5f8b))
* **Report:** init Report.Stack to `string.Empty` ([6adc027](https://github.com/HaloSPV3/SPV3.Loader/commit/6adc027d0db3db43dcbdbac226014cfa2fe49648))
* **Version:** gracefully handle `HXE.Latest` null deserialization ([2fea9d2](https://github.com/HaloSPV3/SPV3.Loader/commit/2fea9d22983643ca82e2476e25be8d3fe4ad57db))
* **Version:** init Address, Content to `string.Empty` and `Version` to a new `Version` object to prevent read-before-init errors ([d046e92](https://github.com/HaloSPV3/SPV3.Loader/commit/d046e92b1ad143ab58e07457b1b8b4933ba3a90d))
* **Version:** restore HttpClient timeout in `finally` clause ([56824e4](https://github.com/HaloSPV3/SPV3.Loader/commit/56824e4ebf7f4de2e7dd1d31c1af7b76e0cf2bd0))

## [2.3.0-alpha.1](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.2.2...v2.3.0-alpha.1) (2026-07-23)

### Features

* **Configuration:** change "Advanced" Settings button to "More Settings..." for clarity ([20d4f42](https://github.com/HaloSPV3/SPV3.Loader/commit/20d4f423b328dffba1cd5c1d2ee9af124ffc7fdf)), closes [#126](https://github.com/HaloSPV3/SPV3.Loader/issues/126)
* **deps:** multi-target n462, net480, and net6.0-windows ([c752ef4](https://github.com/HaloSPV3/SPV3.Loader/commit/c752ef424cb4731123615965e922ab5e90e481c8))
* **Install:** enable DRM patch for everyone who needs it [FREE FOR ALL] ([583047b](https://github.com/HaloSPV3/SPV3.Loader/commit/583047b49a1e54b1b6ad1523c5abb285297cd3db))

### Bug Fixes

* **deps:** add `Meziantou.Polyfill` to use newer features of .NET C# ([b2117b2](https://github.com/HaloSPV3/SPV3.Loader/commit/b2117b2a921a5823a6958d9755a2f5b3d95c0f46))
* **deps:** prefer HXE nupkg; conditionally use HXE git submodule ([bf6a230](https://github.com/HaloSPV3/SPV3.Loader/commit/bf6a230e2ef4f94f2200a7383a33f716039554ac))
* **deps:** re-add Costura.Fody for single-file legacy releases; git-ignore FodyWeavers.xsd ([d148851](https://github.com/HaloSPV3/SPV3.Loader/commit/d1488514d476ec79d4d79c05efc3e9ba06aac332))
* **deps:** remove explicit SourceLink; rely on SDK's built-in SourceLink ([e9247d8](https://github.com/HaloSPV3/SPV3.Loader/commit/e9247d85f1599455b5680eb81b396b56b253b7e5))
* **deps:** remove unused dependency `Microsoft.Windows.Compatibility` ([536cd03](https://github.com/HaloSPV3/SPV3.Loader/commit/536cd03d9fd7b2b5a2ac4400a3a679cbbd242e13))
* **deps:** upgrade bundled Discord Rich Presence DLL to v1.0.5 for non-vandalized images + Firefight maps ([754381c](https://github.com/HaloSPV3/SPV3.Loader/commit/754381caf3e821bfeb949fceba270904b17870b3))
* **deps:** upgrade GitVersion.MsBuild to 6.8.2 ([edbccd8](https://github.com/HaloSPV3/SPV3.Loader/commit/edbccd8fb9fc54c5e6ba3fc36ab329a05acff6e6))
* **Install:** failover to `GetDirectoryRoot` if `GetParent` fails in `ValidateTarget(string)` ([c480950](https://github.com/HaloSPV3/SPV3.Loader/commit/c48095029c545c5602c50bbc79445908ba819c71))
* **News:** handle potential null-references ([cd424a7](https://github.com/HaloSPV3/SPV3.Loader/commit/cd424a712103c851ec29e29cc6c15f3b75d84f85))
* **Social:** update Twitter URL to x.com/halo_legacies ([d02c336](https://github.com/HaloSPV3/SPV3.Loader/commit/d02c336bc3497e6b79dc6c84a9e8c589f3bc5fc3))
* **Version:** replace Git commit `hash` resource with GitVersion `ShortSha` ([6c9dd6f](https://github.com/HaloSPV3/SPV3.Loader/commit/6c9dd6f93e8272ec1dd47881242ccc9a89ccb42a))

### Reverts

* undo pointless changes to `release` script; just needed to install semantic-release ([ef1760c](https://github.com/HaloSPV3/SPV3.Loader/commit/ef1760c5a871230d47964cfff6ba39bde0946e96))

## [2.2.2](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.2.1...v2.2.2) (2021-11-20)

### Bug Fixes

* update Discord App ID ([91d04c2](https://github.com/HaloSPV3/SPV3.Loader/commit/91d04c2b47d0d5e68925b10403d5dfb8c1c1d57f))

## [2.2.1](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.2.0...v2.2.1) (2021-11-15)

### Features

* disable GBuffer and its checkbox if OpenSauce was not installed ([7b93fb8](https://github.com/HaloSPV3/SPV3.Loader/commit/7b93fb84a2ade50ca4beec637c132de22af1dc5b)), closes [HaloSPV3/SPV3-Loader#19](https://github.com/HaloSPV3/SPV3-Loader/issues/19)

### Bug Fixes

* change Changelog feature to approximation of original git log implementation ([d8a6303](https://github.com/HaloSPV3/SPV3.Loader/commit/d8a630317578fceddced72d18f57dab8deea1efb)), closes [HaloSPV3/SPV3.Loader#71](https://github.com/HaloSPV3/SPV3.Loader/issues/71)
* explicitly enable project property 'UseWindowsForms' ([9feb21f](https://github.com/HaloSPV3/SPV3.Loader/commit/9feb21feede7988d2f008101bca0b8d0e67063c8))
* restore Fody Weaver files ([128e276](https://github.com/HaloSPV3/SPV3.Loader/commit/128e276d7f0d90c9c5639778f35d2931d31bbcea))
* set Changelog() to use fetch short semver instead of MajorMinorPatch ([2cb9730](https://github.com/HaloSPV3/SPV3.Loader/commit/2cb97302ad2ef1aba979d09b1095b090a22384eb))
* update remote URLs ([79e446e](https://github.com/HaloSPV3/SPV3.Loader/commit/79e446e78b24f022070dbd3c13f7e47175f17440))

## [2.1.0](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.8...v2.1.0) (2021-10-08)

## [2.2.1](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.2.0...v2.2.1) (2021-11-15)

### Features

* disable GBuffer and its checkbox if OpenSauce was not installed ([7b93fb8](https://github.com/HaloSPV3/SPV3.Loader/commit/7b93fb84a2ade50ca4beec637c132de22af1dc5b)), closes [HaloSPV3/SPV3-Loader#19](https://github.com/HaloSPV3/SPV3-Loader/issues/19)

### Bug Fixes

* change Changelog feature to approximation of original git log implementation ([d8a6303](https://github.com/HaloSPV3/SPV3.Loader/commit/d8a630317578fceddced72d18f57dab8deea1efb)), closes [HaloSPV3/SPV3.Loader#71](https://github.com/HaloSPV3/SPV3.Loader/issues/71)
* explicitly enable project property 'UseWindowsForms' ([9feb21f](https://github.com/HaloSPV3/SPV3.Loader/commit/9feb21feede7988d2f008101bca0b8d0e67063c8))
* restore Fody Weaver files ([128e276](https://github.com/HaloSPV3/SPV3.Loader/commit/128e276d7f0d90c9c5639778f35d2931d31bbcea))
* set Changelog() to use fetch short semver instead of MajorMinorPatch ([2cb9730](https://github.com/HaloSPV3/SPV3.Loader/commit/2cb97302ad2ef1aba979d09b1095b090a22384eb))
* update remote URLs ([79e446e](https://github.com/HaloSPV3/SPV3.Loader/commit/79e446e78b24f022070dbd3c13f7e47175f17440))

## [2.1.0](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.8...v2.1.0) (2021-10-08)

### Features

* deserialize latest.xml to get the latest version of SPV3 Loader ([a0585e5](https://github.com/HaloSPV3/SPV3.Loader/commit/a0585e5c0eb8556beba1fef4c7b9f8ea33dfb6a1))

## [2.0.8](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.7...v2.0.8) (2021-10-03)

### Bug Fixes

* get the Response Content of News.xml correctly ([d24baea](https://github.com/HaloSPV3/SPV3.Loader/commit/d24baeaa4bb019e4a37936dfcb46acf62c925e3d))

## [2.0.7](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.6...v2.0.7) (2021-10-03)

### Bug Fixes

* update latest.xml URL ([718163b](https://github.com/HaloSPV3/SPV3.Loader/commit/718163bd178ff4fc05c4f6b85163a8600dbf5553))

## [2.0.6](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.5...v2.0.6) (2021-10-03)

### Bug Fixes

* update references to HXE's HttpClient ([fc2331e](https://github.com/HaloSPV3/SPV3.Loader/commit/fc2331ec253dbfde3b8440909abf140dcea87439))

## [2.0.5](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.4...v2.0.5) (2021-09-30)

### Bug Fixes

* use UseShellExecute for Process.Start(URL) calls ([12cc806](https://github.com/HaloSPV3/SPV3.Loader/commit/12cc806bad3d39e1f02334eed774bf07f5809108))

## [2.0.4](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.3...v2.0.4) (2021-09-30)

## [2.0.3](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.2...v2.0.3) (2021-09-30)

### Bug Fixes

* fix references to MapApps.Metro 2.x XAML resources ([466cfc0](https://github.com/HaloSPV3/SPV3.Loader/commit/466cfc0631b8d70177f6a86a566e2deb74e9c42f)), closes [HaloSPV3/SPV3-Loader#37](https://github.com/HaloSPV3/SPV3-Loader/issues/37)

### Reverts

* Revert "build: target win10-x64 RuntimeIdentifier" ([267d643](https://github.com/HaloSPV3/SPV3.Loader/commit/267d6434ac195c819c48faf0509a5c752521aeb3))

## [2.0.2](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.1...v2.0.2) (2021-09-24)

### Bug Fixes

* update URL for commit address ([b1a65dc](https://github.com/HaloSPV3/SPV3.Loader/commit/b1a65dc289c481fa82d5d6b237c76b50215e3a17))

## [2.0.1](https://github.com/HaloSPV3/SPV3.Loader/compare/v2.0.0...v2.0.1) (2021-09-24)

### Bug Fixes

* replace assembly location reference for single-file compat ([857d142](https://github.com/HaloSPV3/SPV3.Loader/commit/857d1424d2e7f9b6962f89ef65ae7d74ca119c2d))
* update changelog url ([cfa05fa](https://github.com/HaloSPV3/SPV3.Loader/commit/cfa05faf9d00c9b9636beb8b511d32bcdeed46fe))

## [2.0.0](https://github.com/HaloSPV3/SPV3.Loader/compare/v1.1.8...v2.0.0) (2021-09-24)

### ⚠ BREAKING CHANGES

* minimum .NET Runtime increased to .NET Desktop 6 (effectively reverted in 2.3.0-alpha.1)

## [1.1.8](https://github.com/HaloSPV3/SPV3.Loader/compare/v1.1.7...v1.1.8) (2021-09-21)

### Bug Fixes

* replace COMReference, bypassing WSH with COM Interop ([14a151f](https://github.com/HaloSPV3/SPV3.Loader/commit/14a151f08cf09961db6bb5e5a5e574c78254b18b))

## [1.1.7](https://github.com/HaloSPV3/SPV3.Loader/compare/v1.1.6...v1.1.7) (2021-07-15)

### Bug Fixes

* **SPV3:** Fixed a DRM exploit. ([3570c65](https://github.com/HaloSPV3/SPV3.Loader/commit/3570c6555a55d445db05ce0fd2187af15332cfa8))

## [1.1.6](https://github.com/HaloSPV3/SPV3.Loader/compare/v1.1.5...v1.1.6) (2021-07-15)

### Bug Fixes

* **SPV3:** Only clear SPV3's log if it's larger than 1 MiB ([3f4b661](https://github.com/HaloSPV3/SPV3.Loader/commit/3f4b66176490a48234c3203ec836a58862bc0701))

### Reverts

* Revert "Include HXE into SPV3" ([4024ffa](https://github.com/HaloSPV3/SPV3.Loader/commit/4024ffae14f3fcbe9ab64d2e0685236de15c6768))

## [1.0.0](https://github.com/HaloSPV3/SPV3.Loader/compare/b66fb7d2e7373c209c83d595fd1f8bd1db14d47d...v1.0.0) (2021-07-15)

### Reverts

* Revert "Let SPV3 target x64 only" ([7192d1d](https://github.com/HaloSPV3/SPV3.Loader/commit/7192d1d182ab0a153b00d0b0ce519ac5103693a1))
* Revert "Let the SPV3 Compiler & Installer use the HXE SFX system" ([24e05a4](https://github.com/HaloSPV3/SPV3.Loader/commit/24e05a451f4266c780badfae0a960d57ee788d80))
* Revert "Reference Xidi projects in the SPV3 solution" ([2dd999b](https://github.com/HaloSPV3/SPV3.Loader/commit/2dd999b436afafed8c9bddfc0bec453fb346c0d3))
* Revert "Let the SPV3 Compiler use the HXE SFX system" ([dfc15db](https://github.com/HaloSPV3/SPV3.Loader/commit/dfc15db32870999085dd65b3056372a5eaecf588))
* Revert "Make the SPV3 loader window movable/draggable around the screen" ([7e2a341](https://github.com/HaloSPV3/SPV3.Loader/commit/7e2a34183e190827c31626d2537b9c49d87418fb))
* Revert "Remove finally clause to reduce nesting" ([9fdff2b](https://github.com/HaloSPV3/SPV3.Loader/commit/9fdff2b248648077bb08b66405c4578c423a7ddd))
* Revert "Don't throw exception on asset size mismatch" ([7cf8bdc](https://github.com/HaloSPV3/SPV3.Loader/commit/7cf8bdc00a608058074d3716a5b0fad6b7b237a5))
* Revert "Deprecate the Cli wrapper" ([851cb89](https://github.com/HaloSPV3/SPV3.Loader/commit/851cb8945f830a89db220c1859770564609f9161))
* Revert "Invoke SPV3 directly rather than through HXE's CLI" ([3f71660](https://github.com/HaloSPV3/SPV3.Loader/commit/3f71660d5b7efe4e94fd75ca273dd8f2eb6580c1))
* Revert "Ensure an illusion of choice when prompting for updates" ([b66fb7d](https://github.com/HaloSPV3/SPV3.Loader/commit/b66fb7d2e7373c209c83d595fd1f8bd1db14d47d))
