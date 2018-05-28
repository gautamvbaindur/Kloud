# Kloud
Coding challenge for Kloud

Please create an application that does the following:
1. Produces a list of the owners' names, grouped by their car's brand alphabetically, and sorted by their car's colour alphabetically.
2. Produces a replica service that returns the same results as the API provided.

# Instructions
1. Download solution from git repository
2. Download the Nuget packages
3. Build solution
4. Run the console app - this will hit the api provided by Kloud, do the computations and display the results on the console.
5. Run the unit tests.

# Project Structure:
1. Kloud.BusinessLogic -> This holds the business logic.
2. Kloud.Models -> The entities that need to be consumed and displayed.
3. KloudApp -> The console app to display the results on the screen.
4. KloudApp.Tests -> Unit tests for the business logic

I have also used Dependency Injection using Autofac.

# Note
I was not really sure what you meant by "replica service". So, I created a method that creates the same data structure as provided by the API and serializes it to Json. There is an unit test to verify that the contents are equal. If this is something different from your expectations, please let me know and I would do the required changes.
