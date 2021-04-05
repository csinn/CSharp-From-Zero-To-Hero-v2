## Homework
You have a file called ```Users.txt```. It contains usernames and passwords. A user open your application and they have 3 options:

- ~~Login- enter their username and password, which should match any one line in ```Users.txt```. Successful login will result in "Hello!" printed.~~
- ~~Register- enter their username and password, which should append their credentials at the end of the file. In case of a duplicate user- try again.~~
- ~~Exit- close the application~~

Users.txt file should be at the same directory as the application start .exe.

#### Errors
- ~~If there is no Users.txt file- the application should not throw ```UsersNotFoundException```.~~
- ~~If a Users.text file contains duplicate users, throw a ```DuplicateUserCredentialsException```.~~
#### Restrictions
- Don't use File class static methods.