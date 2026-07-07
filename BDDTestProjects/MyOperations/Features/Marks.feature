Feature: Marks

A short summary of the feature

@tag1
Scenario: Valid marks
    Given Paper1 marks are 50
    And Paper2 marks are 50
    When I calculate the total marks
    Then the final result should be 100
 
Scenario: Invalid Paper1 marks
    Given Paper1 marks are 40
    And Paper2 marks are 50
    When I calculate the total marks
    Then an "Invalid marks" message should be displayed
 
Scenario: Invalid Paper2 marks
    Given Paper1 marks are 50
    And Paper2 marks are 45
    When I calculate the total marks
    Then an "Invalid marks" message should be displayed
 
Scenario: Both marks are invalid
    Given Paper1 marks are 30
    And Paper2 marks are 20
    When I calculate the total marks
    Then an "Invalid marks" message should be displayed
