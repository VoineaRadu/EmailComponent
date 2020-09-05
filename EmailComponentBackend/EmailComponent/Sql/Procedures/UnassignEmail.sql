CREATE PROCEDURE UnassignEmail
    @conversation_id varchar(255)
AS 
BEGIN
UPDATE Emails SET receiver_id = 0 where conversation_id = @conversation_id
END
