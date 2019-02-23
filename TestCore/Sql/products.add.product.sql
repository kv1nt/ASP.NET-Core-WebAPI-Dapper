INSERT INTO Products VALUES(@name);
INSERT INTO ProductDetails VALUES(@@IDENTITY, @color, @description);