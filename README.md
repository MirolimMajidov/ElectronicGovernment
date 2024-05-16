# Electronic government
Everyone knows that the document process (workflow) is one of the important parts of every company. So, we decided and created a system for automating the process of all kinds of documents.
Our system has a server application to provide APIs and a website and a mobile applications too.
1. The server application is built with ASP.Net Core Web API and used several design patterns. It is designed as a rule-based application and uses SQL Server to store data. 
            <a href="https://petstore.swagger.io/?url=https://raw.githubusercontent.com/MirolimMajidov/Jobs/master/src/Services/Identity/Identity.API/Swagger/v1/docs.json">There are APIs to use for other clients;</a>
2. The website is built with Blazor and integrated with a server-side application using authorization. We have created some basic pages that are necessary for our systems. We didn't finish all the pieces, but we made a mockup of the website using Figma, <a href="https://github.com/MirolimMajidov/ElectronicGovernment/blob/master/Resources/Figma%20-%20Mockup%20of%20website.gif">there is a video</a>.   
3. Also we have created mobile app with the MAUI, but we couln't finish intergation with the server app.

# Who uses it?
The application is designed as a multi-tenant application, which means that it serves several companies at the same time. To use this, each organization/company must first add employees and create departments for the necessary parts of the organization. Then create templates for each document type with a document process (workflow). And then, if someone wants to use it, he just needs to select the necessary document template and enter the required fields and send it for processing. Each submitted document is shown to the head of the department according to the workflow and process order. If it is approved or even rejected, the sender will receive a notification via email.
