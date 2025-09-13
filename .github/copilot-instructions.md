# Spread The Word (Continued) - GitHub Copilot Instructions

## Mod Overview and Purpose

**Mod Name:** Spread The Word (Continued)

**Description:** This mod is an update of crazedmonkey231's original mod with added functionality for translation. The main aim of the mod is to incorporate simple Harmony patches that enable you to convert other factions to your ideoligion. The conditions for conversion are linked to mechanics the game considers eligible for goodwill, such as medical treatment and releasing prisoners. These interactions allow pawns to leave converted to your faction's primary ideoligion, contributing towards a faction's conversion count. Upon reaching the configured goodwill amount in conjunction with the necessary conversion count, a faction is converted to your ideoligion.

## Key Features and Systems

- **Convert Then Release for Prisoners:** Functionality that allows prisoner conversion before being released.
- **Framework for Conversion:** Settings include adjustable parameters for the number needed for conversion, minimum goodwill required, and a calculation that considers the number of settlements.
- **Graphical Tracking:** Displays a graph of total pawns converted, assisting with tracking progress.
- **Compatibility:** Works seamlessly with all factions, including those added by other mods, without affecting natural goodwill mechanics.

## Coding Patterns and Conventions

- **Namespace Usage:** Ensure all classes are within an appropriate namespace to maintain structural hierarchy and readability.
- **Static Classes for Utilities:** Utilize static classes, such as `ConversionTrackerUtil` or `StatsFactionUtil`, for utility methods that do not require instance variables.
- **Singleton Use for Components:** Components such as `ConversionTrackerComponent` and `FactionConversionWorldComponent` should make use of singletons or other appropriate design patterns to ensure consistent global access.

## XML Integration

- **Translation Readiness:** XML files should be structured to support localization. Make sure all UI text strings and in-game messages are extracted for translation.

## Harmony Patching

- **Method Patching:** Use Harmony to patch methods in key game classes, such as `Faction_Notify_MemberExitedMap` and `Pawn_GuestTracker_IsInteractionDisabled`.
- **Compatibility Focus:** Ensure patches are non-invasive to maintain compatibility with other mods by targeting specific method signatures and conditions.
- **Logging with Harmony:** Implement logging within Harmony patches to aid debugging and ensure patching successes or failures are recorded.

## Suggestions for Copilot

- **Automate Graphing:** Use Copilot to assist with automating the creation and updating of the conversion graph, utilizing APIs for graph rendering.
- **Optimize Conversion Logic:** Enhance the logic within the conversion calculation by identifying potential optimizations in the codebase.
- **Dynamic Setting Adjustments:** Suggest improvements for dynamic adjustments of settings based on game state or user preferences.
- **Improve Component Interaction:** Optimize interactions among `ConversionTrackerComponent`, `FactionConversionWorldComponent`, and other components for performance and maintainability.
- **Enhance Error Handling:** Use Copilot to provide suggestions for error handling within Harmony patches and component logic.

Feel free to reach out with any suggestions or to report issues you encounter while developing or playing with the mod!
