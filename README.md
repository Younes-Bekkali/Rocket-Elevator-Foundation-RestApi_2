# <b>A .NET Core API deployed on Microsoft Azure</b>
# <b>Rocket Elevator Restful Api</b>

**Week 8 - Offer Services on the Internet** 

**Team:** 

>1. Ukeme Ekpenyong (Team Leader)
>2. Anna Chowattanakul
>3. Younes Bekkali
>4. David Hunter
>5. Jorge Chavarriaga

*To answer the 9 questions with [*Postman:](https://www.getpostman.com/collections/a5cd3bfab68ca5d11069)*
Click the Postman link if you want to import our collection into your Postman domain

1. Retrieving the current status of a specific **Battery**:

**GET:** https://rocketapi.azurewebsites.net/api/battery/69 - *(69 the battery id)* - **SEND**

2. Changing the status of a specific **Battery**:

**PUT:** https://rocketapi.azurewebsites.net/api/battery/69 - *(69 the battery id)*

Select: >Body >raw >JSON

{
        "id": 69,
        "building_id": 69,
        "employee_id": 2,
        "battery_type": "Corporate",
        "status": "active"
}

To change the status: "status": "active" or "inactive"  and press **SEND**

Response:

**The status of the Battery Id: 69 has been changed to: inactive**
To review changes, refer to the first step.

3. Retrieving the current status of a specific **Column**:

**GET:** https://rocketapi.azurewebsites.net/api/column/69 - *(69 the battery id)* - **SEND**

4. Changing the status of a specific **Column**:

**PUT:** https://rocketapi.azurewebsites.net/api/column/69 - *(69 the battery id)*

Select: >Body >raw >JSON

{
        "id": 69,
        "column_type": "Residential",
        "number_floors": 6,
        "status": "inactive",
        "info": "Auxilium ipsa nihil textilis ultio.",
        "notes": "Auxilium ipsa nihil textilis ultio.",
        "battery_id": 24
}

To change the status: "status": "active" or "inactive"  and press **SEND**

Response:

**The status of the Column Id: 69 has been changed to: inactive**
To review changes, refer to the third step.

5. Retrieving the current status of a specific **Elevator**:

**GET:** https://rocketapi.azurewebsites.net/api/elevator/69 - *(69 the elevator id)* - **SEND**

6. Changing the status of a specific **Elevator**:

**PUT:** https://rocketapi.azurewebsites.net/api/elevator/69 - *(69 the elevator id)* 

Select: >Body >raw >JSON

{
    "id": 69,
    "column_id": 20,
    "status": "active"
}

To change the status: "status": "active" or "inactive"  and press **SEND**

Response:

**The status of the Elevator Id: 69 has been changed to: inactive**
To review changes, refer to the fifth step.

7. Retrieving a list of **Elevators** that are not in operation at the time of the request:

**GET:** https://rocketapi.azurewebsites.net/api/elevator/notinoperation - **SEND**

8. Retrieving a list of **Buildings** that contain at least one battery, column or elevator requiring intervention:

**GET:** https://rocketapi.azurewebsites.net/api/building/intervention - **SEND**

9. Retrieving a list of **Leads** created in the last 30 days who have not yet become customers:

**GET:** https://rocketapi.azurewebsites.net/api/lead/notcustomers - **SEND**

# <b>You can also use the following options:</b>
* https://rocketapi.azurewebsites.net/api/battery/all - To retrieve all the batteries availables
* https://rocketapi.azurewebsites.net/api/battery/active - To retrieve all the active batteries
* https://rocketapi.azurewebsites.net/api/battery/inactive - To retrieve all the inactive batteries 
* https://rocketapi.azurewebsites.net/api/column/all - To retrieve all the columns
* https://rocketapi.azurewebsites.net/api/column/active - To retrieve the active columns
* https://rocketapi.azurewebsites.net/api/column/inactive - To retrieve the inactive columns
* https://rocketapi.azurewebsites.net/api/building/all - To retrieve all the buildings
* https://rocketapi.azurewebsites.net/api/building/69 - To retrieve an specific building 
* https://rocketapi.azurewebsites.net/api/customer/all - To retrieve all the customers
* https://rocketapi.azurewebsites.net/api/lead/all - To retrieve all the leads
