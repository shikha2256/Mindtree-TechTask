Feature: LinkGroup
	https://www.linkgroup.eu/


Scenario: 1 Smoke test
#Steps
	When I open the home page
	Then the page is displayed

Scenario: 2 Search results
	Given I have opened the home page
	And I have agreed to the cookie policy
	When I search for 'Leeds'
	Then the search results are displayed
