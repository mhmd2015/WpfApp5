# WpfApp

## Description

This project is a testing to the authentication plugins. It is designed to get authentication from ADFS or PingFederate then can access the REST API's.

## Installation

To install this project on your local machine, follow these steps:

1. Clone the repository: `git clone https://github.com/mhmd2015/WpfApp5`
2. Run the project


## Usage
When run the app in visual studio:
![alt](ui.png)
To use this project, follow these steps:

1. fill the Site Url field with main domain like: **https://my-company.com** and the API URL field with relative to the service or MVC controllers like: **/api/service1/id=1**
2. its recommeneded to save these 2 fields in a local setting store to use them later by click on "Add".
3. click on **Get** button, the app will try to find if there is an authentication info in the cache, if not then will try to open a popup to login to that site.
4. in case you need to clear the authentication info in the cache and start fresh, click on "Clear" button.


## License

This project is licensed under the MIT.

## Contact

If you have any questions, feel free to reach out to us at mhmd2015.
