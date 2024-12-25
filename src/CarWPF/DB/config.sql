CREATE TABLE Road(
    Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    Page INTEGER, 
    Name TEXT, 
    X1 INTEGER, 
    X2 INTEGER, 
    Y1 INTEGER, 
    Y2 INTEGER
);

INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Border", 20, 780, 35, 35);
INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Border", 20, 320, 115, 115);
INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Border", 320, 320, 115, 335);
INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Border", 400, 780, 115, 115);
INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Border", 400, 400, 115, 335);

INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Center", 20, 320, 75, 75);
INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Center", 360, 360, 115, 335);
INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
    VALUES(1, "Center", 400, 780, 75, 75);


CREATE TABLE Vertices(
    Id INTEGER PRIMARY KEY NOT NULL, 
    Page INTEGER, 
    Left INTEGER, 
    Top INTEGER
);

INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(1, 1, 30, 95);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(2, 1, 160, 95);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(3, 1, 200, 95);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(4, 1, 370, 95);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(5, 1, 160, 310);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(6, 1, 200, 310);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(7, 1, 370, 55);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(8, 1, 200, 55);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(9, 1, 160, 55);
INSERT INTO Vertices (Id, Page, Left, Top) 
    VALUES(10, 1, 30, 55);


CREATE TABLE Edges(
    Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    Page INTEGER, 
    FromId INTEGER,
    ToId INTEGER,
    NotAllowedFromId INTEGER
);

INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 1, 2, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 2, 3, 8);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 2, 5, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 3, 4, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 3, 9, 2);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 6, 3, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 7, 8, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 8, 2, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 8, 9, NULL);
INSERT INTO Edges (Page, FromId, ToId, NotAllowedFromId) 
    VALUES(1, 9, 10, NULL);

.exit