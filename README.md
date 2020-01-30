# ServiceManual
=== REST API FOR SERVICEMAUAL ===

=== DESCRIPTION ===

This is a simple Restful API created with Visual Studio 2019 using Asp.net Core.
The meaning of this project is to manage service manual data through API.
This project can use GET, POST, PUT and DELETE methods to manage the data.

=== PREREQUISITES ====

Please use Postman as your Api testing device.
If you do not have Postman installed, you can download it here https://www.getpostman.com/
In Postman, from the left upper corner select File -> Settings -> SSL certificate verification OFF.
After testing the API remember to turn this setting back ON.

=== HOW TO USE ===

Open the project and run it.
It opens an empty HTTP site with an address ending in /api/.
DO NOT CLOSE THE WEBSITE OR YOU HAVE TO RE-RUN THE PROJECT.
Copy this address and open Postman. 
In the Postman there is a drop-down menu for GET, POST, PUT and DELETE methods with an empty address bar.
Use these methods and address bar for testing the API.

=== GET ===

Select the GET method from the menu and insert your address like so:
	
	https://localhost:XXXXX/api/services/
	https://localhost:XXXXX/api/devices/

Below the address bar, click Body -> raw and select JSON to see the data in JSON format.
/api/devices shows a list of all devices and their corresponding services.
/api/services shows a list of all services that are awaiting for handling.
You can search a single item by ID by adding the ID number to the end of the address.

 	https://localhost:XXXXX/api/services/1
	https://localhost:XXXXX/api/devices/1

You can also search a services within devices using following address:

	https://localhost:XXXXX/api/services/searchservice?type=Device

You can sort the services list by ascending or descending order (based on importance) with address:
	
	https://localhost:44392/api/services?sort=REPLACE  (REPLACE = desc or asc)

=== POST ===

Select the post method from menu, and use the address https://localhost:XXXXX/api/services
in the body method, use the following foundation for adding the correct information.

 	{
        "date": "01/10/2019",
        "time": 1100,
        "description": "Check check",
        "importance": "1",
        "state": true
	"DeviceId": 1
    	}

Id is automatically incremented , enter Date and time using the format seen above. You have to enter time 
without using . or : to seperate minutes (ie. 09:30 would be 930).
Write a description of your choice, and use numbers to indicate the importance (1 is the highest).
For states use true or false, indicating whether the service is complete or not.
Enter the device ID according to which device needs to be handled.
When you're ready press Send

=== PUT ===

Use the PUT method to update the existing data. To update data for a service,
use the address https://localhost:44392/api/services/ID (ID is the number of the service).
Again use the body to enter the updated text with the following format:

	{	
        "date": "01/10/2019",
        "time": 1100,
        "description": "Check check",
        "importance": "1",
        "state": true
	"DeviceId": 1
    	}

=== DELETE ===

If you want to delete data from services, use the DELETE method.
You have to specify a single item in order to delete it. Use the following address:

	https://localhost:44392/api/services/ID (ID = service number ie. 1)

After specifying the item press Send to delete it.

