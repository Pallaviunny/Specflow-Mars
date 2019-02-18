Feature: AddSkills
	In order to update my profile
	As a skill trader
	I want to add the skills I know

@mytag
Scenario:Check if user could able to add skills
	Given I clicked on the skill tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings
