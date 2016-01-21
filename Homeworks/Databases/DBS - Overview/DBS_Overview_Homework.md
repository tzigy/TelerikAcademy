## Database Systems - Overview
### _Homework_

1. What database models do you know?
    - Common logical data models for databases include:
        * Hierarchical database model
        * Relational model
        * Entity–relationship model
        * Enhanced entity–relationship model
        * Network model
        * Object model
        * Document model
        * Entity–attribute–value model
        * Star schema
     
    - Physical data models include:
        * Inverted index
        * Flat file
    
    - Other models include:
        * Associative model
        * Multidimensional model
        * Multivalue model
        * Semantic model
        * XML database
        * Named graph
    * Triplestore
    
1. Which are the main functions performed by a Relational Database Management System (RDBMS)?
    * Creating / altering / deleting tables and relationships between them (database schema)
    * Adding, changing, deleting, searching and retrieving of data stored in the tables
    * Support for the SQL language
    * Transaction management (optional)
    
1.  Define what is "table" in database terms.
    * Database tables consist of data, arranged in rows and columns, All rows have the same structure. Columns have name and type (number, string, date, image, or other).

1.  Explain the difference between a primary and a foreign key.
    * Primary key is a column of the table that uniquely identifies its rows (usually its is a number). The foreign key is an identifier of a record located in another table which usually its primary key.
    
1.  Explain the different kinds of relationships between tables in relational databases.
    * one- to- one - the relationship between two entities A and B in which one element of A may only be linked to one element of B, and vice versa.
    * one- to- many - the relationship between two entities A and B in which element of A may be linked to many elements of B, but a member of B is linked to only one element of A.
    * many- to- many - the relationship between two entities (see also entity–relationship model) A and B in which A may contain a parent record for which there are many children in B and vice versa.
    
1.  When is a certain database schema normalized? What are the advantages of normalized databases?
    * Normalisation is the process of organizing the columns and tables (relations) of a relational database to minimize data redundancy. Normalization  involves decomposing a table into less redundant (and smaller) tables (removes repeating data) without losing information. 
    
1.  What are database integrity constraints and when are they used?
    * Integrity constraints are used to ensure accuracy and consistency of data in a relational database. Data integrity is handled in a relational database through the concept of referential integrity. Many types of integrity constraints play a role in referential integrity (RI).
        * Primary Key Constraints
        * Unique Constraints
        * Foreign Key Constraints
        * NOT NULL Constraints
        * Check Constraints
        * Dropping Constraints

1.  Point out the pros and cons of using indexes in a database.
    * Advantages- faster lookup for results (speed up searching of values).
    * Disadvantages- adding and deleting records ist slower.
      
1.  What's the main purpose of the SQL language?
    * SQL is  designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS). SQL consists of a data definition language, data manipulation language, and a data control language. The scope of SQL includes data insert, query, update and delete, schema creation and modification, and data access control.
    
1.  What are transactions used for? Give an example.
    * Transactions are a sequence of database operations which are executed as a single unit. That means that either all of them execute successfully or none of them is executed at all. An example is a bank transfer from one account into another.
    
1.  What is a NoSQL database?
    * A NoSQL database environment is, simply put, a non-relational and largely distributed database system that enables rapid, ad-hoc organization and analysis of extremely high-volume, disparate data types. NoSQL databases are sometimes referred to as cloud databases, non-relational databases, Big Data databases and a myriad of other terms and were developed in response to the sheer volume of data being generated, stored and analyzed by modern users (user-generated data) and their applications (machine-generated data).
In general, NoSQL databases have become the first alternative to relational databases, with scalability, availability, and fault tolerance being key deciding factors. They go well beyond the more widely understood legacy, relational databases (such as Oracle, SQL Server and DB2 databases) in satisfying the needs of today’s modern business applications. A very flexible and schema-less data model, horizontal scalability, distributed architectures, and the use of languages and interfaces that are “not only” SQL typically characterize this technology.

1.  Explain the classical non-relational data models.
    * The non-relational data model would look more like a sheet of paper. In fact, the concept of one entity and all the data that pertains to that one entity is known in Mongo as a “document”, so truly this is a decent way to think about it. You just add things whenever you need them. Your software doesn’t need to know ahead of time, you don’t need to know ahead of time. It all just kind of works, provided you know what you’re doing on the software level.
    
1.  Give few examples of NoSQL databases and their pros and cons.
    * Redis- ultra-fast in-memory data structures server
    * MongoDB- mature and powerful JSON-document database
    * CouchDB- JSON-based document database with REST API
    * Cassandra- sistributed wide-column database
