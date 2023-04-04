Feature: To test the post request

A short summary of the feature

@tag1
Scenario: POST Request testing
	Given the user sends a post request with url "https://reqres.in/api/users"
	Then the user should get a success response
