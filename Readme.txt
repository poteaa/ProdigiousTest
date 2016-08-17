Solution projects:

ProdigiousTest.DataBase: database created by using entityframework. It contains 4 tables:
- Product table: has the information to show in the test
- Supplier table: suppliers for products
- User: user base to authenticate user and secure web api by generating a token and secure the MVC project.
- City table: cities for the users

ProdigiousTest.DataAccess: layer to access to database.

ProdigiousTest.Model: has the model for the web api. Contains all the logic and DTO's to get and set data to 
the database. 

ProdigiousTest.Security: provides security for WebApi. For this test I am using the encrypted password as 
the token.

ProdigiousTest.WebAPI: rest API

ProdigiousTest.MVC: presentation layer. It uses links to classes of ProdigiousTest.Model.

To log into the application there is only one user:
UserName: Diego
PassWord: 123