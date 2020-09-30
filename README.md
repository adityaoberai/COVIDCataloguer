# TagCOVID
An application to help healthcare institutions catalog patient contact details from the comfort of their smartphones or PCs

## Inspiration
Looking at the current scenario with COVID-19 and the increasing infected numbers on a daily basis, it has become more and more difficult for healthcare institutions to keep track of patients who have been infected, especially in smaller towns and villages which may not have the best of infrastructure and connectivity with other towns and metropolitan cities. 

In order to help provide a possible solution to this problem, I have created a cross-platform application using Xamarin.Forms and the Azure Cosmos DB API for MongoDB to help catalogue the contact details of patients who are visiting the healthcare institutions and getting themselves tested. This application will definitely benefit towns and villages where healthcare institutions such as clinics and blood banks do not have access to desktop or laptop computers but do have accessibility to smartphones.

I have chosen to work on this project because I believe that such a project can help impact those busy running our healthcare industry and thus, the citizens of our nation. 

## What it does

TagCOVID is designed to be used by hospital staff only so the application’s access shall be restricted from the general patients. It features two major functionalities:

•	Add Patient Details to Database  
•	Check if Patient Details are Present  

The staff using the application will be able to see various input fields allowing them to input the following personal details of the patient:

•	Patient Name  
•	Patient Phone Number  
•	Patient Email Address  
•	Patient COVID-19 Status  

Based on these details, the information will be either added to the database for the first time or updated in case it is already present through the “Add/Update” button. This will also send an email to the patient as soon as the details are inputted to the database.  

If the staff needs to then check if the patient details have been added to the database or not, they can do so clicking on the “Check” button. In order to do so, they must input the patient’s phone number first. If the patient’s phone number is not found in the database, it shall tell us that the information was not found using the text boxes below the button. If the details are found however, the patient’s name, email address and COVID-19 status shall become visible in the same text boxes.  
 
Another feature that will be unlocked if the details are found in the database is the “Email Details” button. Clicking on this button will allow the user to automatically send the patient information that has just been checked to the already inputted email address.


## How I built it

Having former experience with Java due to my curriculum (and recognising the similarities with the C# syntax) as well as desiring to build a cross-platform application, I decided to learn how to develop a Xamarin.Forms application. I used XAML to create the UI of the application and C# for the back-end code. As far as my database requirement went, I chose to use MongoDB (via the Azure Cosmos DB API) due to its schema less structure and ease of scale-out. As I chose to work with Xamarin.Forms, Visual Studio automatically became the IDE of preference.

## Challenges I ran into

There were a few challenges that I ran into since this was the first proper application that I have created:

•	Understanding asynchronous programming and why the keywords async and await are necessary  
•	Understanding the concepts behind NoSQL Databases due to my lack of former experience  
•	Using the Azure Cosmos DB API for MongoDB in Xamarin.Forms (which I could only understand using the code samples from Microsoft documentation)   

## Accomplishments that I'm proud of

I built my first ever application for mobile devices as well as used a NoSQL cloud database for the first time ever, which is something that I am extremely proud of. And I believe I have fulfilled the requirements of the project that I had kept in mind in the time I had and have built a project which may be useful to a social cause.

## What I learned

I have learnt the following concepts in the last 2 days:

•	Creating basic UIs using XAML  
•	Developing cross-platform applications using Xamarin.Forms  
•	Using MongoDB with C#/.NET for application development  
•	Using Azure Cosmos DB API for the MongoDB database  
•	Making the best use of the Visual Studio IDE for efficiency in application development  


## What's next for TagCOVID

I shall work on implementing Blockchain features to improve the security of the data being stored.
