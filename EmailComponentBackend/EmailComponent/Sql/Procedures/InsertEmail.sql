CREATE PROCEDURE InsertEmail
    @subject VARCHAR(255), 
    @message VARCHAR(MAX),
    @is_readed BIT, 
    @date BIGINT, 
    @conversation_id VARCHAR(255),
    @sender_id INT,
    @receiver_id INT 
AS 
INSERT INTO Emails (
    subject, 
    message, 
    is_readed, 
    date, 
    conversation_id, 
    sender_id, 
    receiver_id
    )
     values 
    (
    @subject, 
    @message,   
    @is_readed,
    @date,
    @conversation_id,
    @sender_id, 
    @receiver_id
    )