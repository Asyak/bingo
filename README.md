# bingo
/****************************************************

bingo: Tarantino soundtrack game

*****************************************************/

This project has been constructed with C#, Visual Studio 2017 running asp.net 4.7 version

Author: Asya Kagansky


*** Game description: ***
A little game to test your Tarantino soundtrack knowledge.
Home page proposes an embedded Spotify resource of a song which is used in one of
Tarantino films. Try to guess which one among 3 proposed options is the correct one. 
The resource plays for 30 seconds, then you can hear it again or go to Spotify
to listen the full version.
The goal is to gain 100 points in 10 steps. 

*** Architecture description: ***
This is a very simple web form application. 
It does not use any DataBase. Data filled statically as the page loads.
As you play a turn, the page goes to server and back, at least for 10 times.
I chose viewstate variables to store data between these client-server navigations. 
There is a Test project added.

Created files organised as follows:

MasterPages folder => contains From.Master, specific Master Page. 
SpecificPages folder => contains content pages:
	1. Home.aspx page - start  page, run it to play the game.
	2. Gameover.aspx page - this  page is displayed when you have played your turn. 
	3. Error.aspx page - this page is displayed is case of error.
	4. Songs.cs - Defines Song object, its properties and methods.
Images folder => Images specific to this project.
CustomCss folder => custom-styles.css Related stylesheet.

All other folders and files were automatically generated. 


*** Tests ***
bingo.Test project
HomeTests.cs class


*** Future improvements: ***
1. To stock songs in XML file and to fill the playlist from XML file instead of filling it in the page.
2. To use the Update panel control instead of viewstate variables -> not sure, to test.
3. To add a validate form test in case a user did not choose any of radio options.


*** Any comments are welcome. Thank you ***
