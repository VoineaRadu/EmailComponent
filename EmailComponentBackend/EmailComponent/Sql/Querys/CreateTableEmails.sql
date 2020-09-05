CREATE TABLE Emails
(
    email_id INT IDENTITY PRIMARY KEY,
    subject VARCHAR(255) NOT NULL,
    message VARCHAR(MAX) NOT NULL,
    is_readed BIT NOT NULL,
	sender_id INT,
	receiver_id INT,
	date BIGINT,
	conversation_id VARCHAR(255),
);