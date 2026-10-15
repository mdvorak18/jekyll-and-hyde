// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class JekyllAndHyde : ModuleRules
{
	public JekyllAndHyde(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"JekyllAndHyde",
			"JekyllAndHyde/Variant_Platforming",
			"JekyllAndHyde/Variant_Platforming/Animation",
			"JekyllAndHyde/Variant_Combat",
			"JekyllAndHyde/Variant_Combat/AI",
			"JekyllAndHyde/Variant_Combat/Animation",
			"JekyllAndHyde/Variant_Combat/Gameplay",
			"JekyllAndHyde/Variant_Combat/Interfaces",
			"JekyllAndHyde/Variant_Combat/UI",
			"JekyllAndHyde/Variant_SideScrolling",
			"JekyllAndHyde/Variant_SideScrolling/AI",
			"JekyllAndHyde/Variant_SideScrolling/Gameplay",
			"JekyllAndHyde/Variant_SideScrolling/Interfaces",
			"JekyllAndHyde/Variant_SideScrolling/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
