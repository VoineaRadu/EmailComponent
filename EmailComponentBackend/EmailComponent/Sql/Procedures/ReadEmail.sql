CREATE PROCEDURE ReadEmail
    @email_id int
AS 
BEGIN
UPDATE Emails SET is_readed = 1 where email_id = @email_id
END