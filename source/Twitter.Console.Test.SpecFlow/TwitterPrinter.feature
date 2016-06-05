Feature: TwitterPrinter

Scenario: Printer displays tweets in correct order
	Given I have a list of users and tweets
	And the tweets are in a specific order
	When I print the twitter feed
	Then the tweets are in the correct order
