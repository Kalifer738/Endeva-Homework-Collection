CREATE TABLE products (
	product_no INTEGER PRIMARY KEY AUTOINCREMENT,
	product_name TEXT,
	product_disc TEXT,
	product_price REAL
);

CREATE TABLE customers (
	cust_no INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name TEXT,
	username TEXT,
	password TEXT,
	email TEXT,
	contact_no TEXT,
	address TEXT,
	postcode TEXT
);

CREATE TABLE orders (
	order_no INTEGER PRIMARY KEY AUTOINCREMENT,
	product_no INTEGER,
	quantity INTEGER,
	sub_total REAL,
	FOREIGN KEY(product_no) REFERENCES products(product_no)
);

CREATE TABLE invoices (
	order_no INTEGER,
	cust_no INTEGER,
	date INTEGER,
	total REAL,
	FOREIGN KEY(order_no) REFERENCES orders(order_no),
	FOREIGN KEY(cust_no) REFERENCES customers(cust_no)
);

INSERT INTO products (product_no, product_name, product_disc, product_price) VALUES
(1, 'Chais', 'A sweet tea blend', 18.00),
(2, 'Chang', 'A refreshing lager', 19.00),
(3, 'Good Morning Tea', 'A nice blend of herbs for tea', 10.00),
(4, 'Strawberry Syrup', 'A refreshing summer concentrate', 21.35),
(5, 'Tofu', 'Soy-based protein', 23.25);

INSERT INTO customers (cust_no, first_name, username, password, email, contact_no, address, postcode) VALUES
(101, 'Ivan', 'ivanko', 'pass123', 'ivan.p@example.com', '+359897574242', 'Street Borisova', '7000'),
(102, 'Maria', 'maria_s', 'secure456', 'maria.s@example.com', '359897574242', 'Street Bulgaria', '7000'),
(103, 'Peter', 'pete_b', 'mypw789', 'peter.b@example.com', '359897574242', 'Street Beli Hrizantemi', '7000'),
(104, 'Elena', 'elena_v', 'vstrongpw', 'elena.v@example.com', '359897574242', 'Street Fantasy', '7000');

INSERT INTO orders (order_no, product_no, quantity, sub_total) VALUES
(1, 2, 5, 95.00),
(2, 1, 10, 180.00),
(3, 4, 2, 42.70),
(4, 5, 3, 69.75),
(5, 1, 20, 360.00),
(6, 2, 1, 19.00),
(7, 3, 50, 500.00);

INSERT INTO invoices (order_no, cust_no, date, total) VALUES
(1, 101, 20251101, 95.00),   -- Cust 101 (Ivan) : Total Orders = 2
(2, 102, 20251102, 180.00),  -- Cust 102 (Maria): Total Orders = 1
(3, 101, 20251103, 42.70),   -- Cust 101 (Ivan) ------------------
(4, 103, 20251104, 69.75),   -- Cust 103 (Peter): Total Orders = 2
(5, 104, 20251105, 360.00),  -- Cust 104 (Elena): Total Orders = 2, Total Value = 860.00 (ex. 4)
(6, 103, 20251106, 19.00),   -- Cust 103 (Peter)------------------
(7, 104, 20251107, 500.00);  -- Cust 104 (Elena)------------------

/* 1. Извадете списък на всички поръчки, където има продукт 'Chang'; */
SELECT ord.order_no, ord.product_no, prd.product_name FROM orders AS ord
RIGHT JOIN products AS prd ON ord.product_no = prd.product_no
WHERE prd.product_name = "Chang";

/* 2. Извадете всички имена на клиенти, които са си поръчали продукт 'Chais'; */
SELECT cst.cust_no, cst.first_name, cst.username, cst.contact_no FROM orders AS ord
RIGHT JOIN products AS prd USING(product_no)
RIGHT JOIN invoices AS inv USING(order_no)
RIGHT JOIN customers AS cst USING(cust_no)
WHERE prd.product_name = "Chais";

/* 3. Извадете списък на всички потребители, които имат повече от една поръчка; */
SELECT COUNT(ivc.cust_no) AS cstOrds, ivc.cust_no FROM invoices AS ivc
GROUP BY ivc.cust_no
HAVING cstOrds > 1;

/* 4. Извадете списък на всички потребители, които са направили поръчки на обща стойност над 500 (USD); */
SELECT SUM(ivc.total) AS cstTotal, ivc.cust_no FROM invoices AS ivc
GROUP BY ivc.cust_no
HAVING cstTotal > 500;