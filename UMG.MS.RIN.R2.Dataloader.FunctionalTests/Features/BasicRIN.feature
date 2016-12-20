Feature: R2 Resource

#Scenario: RIN SoundRecording Title Text becomes the R2 Resource Title
#	Given a RIN with this sound recording information
#		| TitleText  |
#		| Some Title |
#	When I transform that RIN for the R2 Data Loader
#	Then R2 Data Loader structure will have this Resource information
#		| Title      |
#		| Some Title |


Scenario: RIN SoundRecording Title Text becomes the R2 Resource Title
	Given a RIN with this sound recording information
		| TitleText  |
		| Some Title |
	When I transform that RIN for the R2 Data Loader
	Then R2 Data Loader structure will have this Resource information
		| Title      |
		| Some Title |
