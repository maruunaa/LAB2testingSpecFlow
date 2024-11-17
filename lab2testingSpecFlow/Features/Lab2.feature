@setup_feature
Feature: Lab2


Scenario: Successful login with valid credentials
    Given I am on the SauceDemo login page
    When I enter valid username "locked_out_user" and password "secret_sauce"
    Then I should see an error message "Epic sadface: Sorry, this user has been locked out."
