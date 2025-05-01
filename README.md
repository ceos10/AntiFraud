# Challenge

<details open><summary> Running the app </summary> <br />
Follow the next steps:

1. Clone repository:
   ```bash
   git clone https://github.com/ceos10/AntiFraud.git
   ```
2. Start the Kafka using Docker Compose:
   ```bash
   cd AntiFraud   
   docker compose up
   ```
3. Open the project in Visual Studio and configure multiple startup projects: Transaction and AntiFraud
4. Run the services AntiFraud and Transaction
5. Use the create transaction call in Swagger to create a transaction with a value of 3000 and check the TransactionExternalId in the response
6. Use the get transaction call in Swagger using the id from the previous step and validate that the status is 3 (Rejected)
7. Use the create transaction call in Swagger to create a transaction with a value of 1000 and check the TransactionExternalId in the response
8. Use the get transaction call in Swagger using the id from the previous step and validate that the status is 2 (Approved)
   ```
</details>