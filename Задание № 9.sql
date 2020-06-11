create table productToCategory
(
	IdProductToCategory int not null identity Primary key,
	IdProduct int not null,
	IdCategory int not null,
	foreign key(IdProduct) REFERENCES Product (IdProduct),
	foreign key(IdCategory) REFERENCES Category (IdCategory)
);

select p.NameProduct, c.NameCategory
from Product p 
left join ProductToCategory pToc on p.IdProduct = pToc.IdProduct left join Category c on pToc.IdCategory = c.IdCategory