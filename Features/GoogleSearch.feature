Feature: ToSearch
	Search the give item in google paage and display the titel of selected link

@ToSearch
Scenario: Search rquested item in google
	Given that I have to navigate google search bar
	Then Enter the search item in google serach bar
	Then Click on search button
	Then find number of related links found in page
	Then scroll down page and click to next page
	Then Click on first link 
	Then displayy the title of page
    And close the browser