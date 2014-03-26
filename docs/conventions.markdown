#Project Conventions

1. Convention for configuration
  * All new micro configuration files will live under the source/config folder. The file will have an .erb extension after its real extension ex:
   blah.txt.erb

2. All tests for a component will live under the app.specs project in a file named [Subject]Specs.rb.

3. Null is not an allowable return value from value returning methods that we write. Either leverage null object or raising an exception, to simplify the need to not handle nulls in the calling code.

