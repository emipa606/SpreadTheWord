# GitHub Copilot Instructions for Spread The Word (Continued)

## Mod Overview and Purpose

Spread The Word (Continued) is an update to crazedmonkey231's mod, which aims to convert other factions to your ideology in RimWorld. The mod allows players to control the conditions required for faction conversion through settings. Players can configure the number needed for conversion, the minimum goodwill required, and a complex calculation that takes into account the number of settlements. The mod also includes a graph to track the total number of pawns converted.

## Key Features and Systems

- **Convert then Release for prisoners**: Allows players to convert prisoners and release them to convert factions.
- **Settings for conversion**: Players can configure the number needed for conversion, minimum goodwill required, and a complex calculation that takes into account the number of settlements.
- **Graph for total pawns converted**: Provides a visual representation of the total number of pawns converted.

## Coding Patterns and Conventions

### C# Coding Patterns
- **Modular Design**: Code is organized into separate classes for different functionalities (e.g., `ConversionTrackerComponent`, `HarmonyPatches`, `HistoryAutoRecorderWorker_Proselytizers`).
- **Data Exposure**: Use the `ExposeData` method to expose data for save/load functionality.
- **Finalization**: Use the `FinalizeInit` method to perform final initialization tasks after all mods have been loaded.
- **Harmony Patches**: Utilize Harmony patches to modify the game's behavior (e.g., `WorkGiver_Warden_Convert`).

### XML Coding Patterns
- **Defs Structure**: XML files are used to define various game elements such as `HistoryAutoRecorderGroupDef`, `HistoryAutoRecorderDef`, and `PrisonerInteractionModeDef`.
- **Dependency Management**: Include dependencies in the `About.xml` file to ensure required mods are loaded.

## XML Integration

XML files are essential for defining game elements such as `HistoryAutoRecorderGroupDef`, `HistoryAutoRecorderDef`, and `PrisonerInteractionModeDef`. These files are located in the `Defs` directory and should be structured according to RimWorld's XML conventions. Ensure that all XML files are correctly referenced in the `LoadFolders.xml` file.

## Harmony Patching

Harmony patches are used to modify the game's behavior without altering the original code. In Spread The Word (Continued), Harmony patches are used to implement the conversion logic. Key classes for Harmony patches include:
- `WorkGiver_Warden_Convert`: Contains postfix and prefix methods to modify the behavior of the work giver responsible for converting prisoners.
- `ConversionTrackerComponent`: Manages the conversion process and tracks the number of pawns converted.

## Suggestions for Copilot

### C# Suggestions
- **Modular Design**: When creating new classes, consider their role in the mod's functionality and organize them accordingly.
- **Data Exposure**: Ensure that all data that needs to be saved and loaded is exposed using the `ExposeData` method.
- **Finalization**: Use the `FinalizeInit` method to perform any final initialization tasks after all mods have been loaded.

### XML Suggestions
- **Defs Structure**: When creating new XML files, ensure they are structured according to RimWorld's XML conventions and include the necessary dependencies in the `About.xml` file.
- **Dependency Management**: Ensure that all XML files are correctly referenced in the `LoadFolders.xml` file to avoid loading issues.

### Harmony Patching Suggestions
- **Prefix/Postfix Methods**: Use prefix and postfix methods to modify the behavior of existing methods without altering the original code.
- **Conversion Logic**: Ensure that the conversion logic is implemented correctly and that all conditions required for conversion are met.

By following these guidelines, you can effectively use GitHub Copilot to assist with development in the Spread The Word (Continued) mod. If you encounter any issues, please refer to the mod's documentation or seek assistance on the Discord channel.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

