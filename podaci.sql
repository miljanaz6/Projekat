SET IDENTITY_INSERT [Case] ON;
INSERT INTO [Case] (ID,Oznaka,Kapacitet,Napunjenost,GameID)
VALUES 
(1,'čaša11',4,4,1),
(2,'čaša12',4,4,1),
(3,'čaša13',4,0,1),
(4,'čaša21',4,4,1),
(5,'čaša22',4,4,1),
(6,'čaša23',4,4,1),
(7,'čaša24',4,0,1),
(8,'čaša25',4,0,1)
SET IDENTITY_INSERT [Case] OFF;

SET IDENTITY_INSERT [Boje] ON;
INSERT INTO [Boje] (ID,red1,red2,red3,red4,CasaId)
VALUES 
(1,'pink','green','pink','green',1),
(2,'green','pink','green','pink',2),
(3,'white','white','white','white',3),
(4,'green','purple','red','green',4),
(5,'red','red','green','purple',5),
(6,'purple','red','green','purple',6),
(7,'white','white','white','white',7),
(8,'white','white','white','white',8)

SET IDENTITY_INSERT [Boje] OFF;

SET IDENTITY_INSERT [Igrica] ON;
INSERT INTO [Igrica] (ID,Ime)
VALUES 

(1,'Igrac1')

SET IDENTITY_INSERT [Igrica] OFF;