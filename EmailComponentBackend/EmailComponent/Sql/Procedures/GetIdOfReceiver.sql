CREATE PROCEDURE GetIdOfReceiver
      @receiver_email varchar(255)
AS
BEGIN
	SELECT user_id FROM Users WHERE email = @receiver_email;
END