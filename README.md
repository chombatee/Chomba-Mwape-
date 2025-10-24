Hi There Welcome to the CMCMS

The contract monthly claims management system is a practical application created for Independent contractor lecturers to simplify the often complex claim submission and approval processes that lecturers and program co-ordinators struggle with it is a ASP.NET MVC application written in C#👩🏾‍💻

My aim during the development process to enhance accuracy, efficiency, and user satisfaction in claiming management. This application was developed to allow users(lecturers and program coordinators ) be able to lecturers will submit monthly claims with calculated totals based on hours they worked and their hourly rates.to register by providing their full name, email, role, module, username and password.

Development breakdown :

The application allows users to register by providing their username, full name, email, role, module, and password. I created The action method “Registers” to handles the insertion of new user records into a database. It connects to the database and executes an INSERT SQL command to add a new user User Login:

Users can log in using their email and password. I names the action method “Login” it will checks the users provided credentials against the database and updates the active user session in the database. Logout Functionality The “logout” method resets the active user status in the database and redirects to the index view.

Claims Submission:

The lectures can submit claims by uploading supporting documents and providing details such as the module, claim date, period, hourly rate, hours worked, and a description.

A total claim amount will automatically appear once hourly rate and total hours have been inserted our next action method is named “claiming” and it processes the uploaded file and stores the claim details in the database.

Claims Approval by program coordinator :

The program coordinators page has a functionality for approving or rejecting claims.

I created an action method named “approves” it updates the status of claims in the database based on user input.

Dashboard and Profile Management:

Within this application includes “views “ for user dashboards and profiles, which will display user-specific information or claims for both lectures program coordinators. Error Handling:

Withing the application there is error handling for various operations, including database connections and file uploads.

Basic error handling is implemented using try-catch blocks, although it could be improved with more specific error messages and logging.

Database Connections:

We created a data base query to which the contract monthly claims management system uses SqlConnection and SqlCommand from System.Data.SqlClient to interact with a SQL Server database. To save the data of all users.

File Uploads:

Update The application now allows users to upload supporting files PDFs and Word documents related to their claims. Uploaded files are saved in a designated folder within the wwwroot directory.

INSTRUCTION MANUAL ON HOW TO USE CMCMS

STEP 1 Start by Registering for an account by Entering your full Name, Email Address,role, module, desired Username and Password. step 2
login using the same username and password.

Step3 Lecturers can to submit a claim after they finish submitting lecturers can then Click submit claim now their claim will be submitted 

STEP 4 The program coordinator can login or create an account if lecturers have not registered their account this is in order to give approval or reject thelecturers claim

STEP 5 claims page is where lecturers will see a record the claims submitted
Program coordinators have access to the supporting documents submitted by lecturers who have made a claim by clicking “View Document” and the document will download instantly onto your computer Step 6 You will get a “success” message for approval or success for rejection

step 7 a last the lecturer will be able to go back into his profile under “track claims” to see whether or not the claim has been approved

Enjoy🌸
