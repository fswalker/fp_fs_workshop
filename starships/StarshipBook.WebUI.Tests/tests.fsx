#r "../packages/canopy/lib/canopy.dll"
#r  "../packages/Selenium.WebDriver/lib/net40/WebDriver.dll"
#I "../packages/Selenium.WebDriver.ChromeDriver/driver"

open canopy
open runner

configuration.chromeDir <- __SOURCE_DIRECTORY__ + "/../packages/Selenium.WebDriver.ChromeDriver/driver/"
start chrome

url "http://127.0.0.1:8083/index.html"

notContains "Context info goes here" <| read ".movie-context-info"

canopy.runner.failedCount
