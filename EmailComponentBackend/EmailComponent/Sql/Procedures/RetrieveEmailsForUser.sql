CREATE PROCEDURE RetrieveEmailsForUser
	@user_id varchar(255)
AS
BEGIN
	SELECT email_id, subject, message, is_readed, date, conversation_id, first_name, last_name, email
    FROM emails 
    INNER JOIN users
    ON emails.sender_id = users.user_id  where receiver_id = @user_id
END

