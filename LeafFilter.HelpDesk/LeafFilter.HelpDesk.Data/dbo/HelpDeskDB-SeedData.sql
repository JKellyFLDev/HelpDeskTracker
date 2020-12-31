/** HEADER
===============================================================================
NAME: James Kelly
DESCRIPTION: Seed Script for type objects and other basic information
NOTES:
HISTORY:
-------------------------------------------------------------------------------
[2020-11-24] - [jkelly] - Initial Creation
===============================================================================
END HEADER **/
DECLARE @User VARCHAR(10) = 'jkelly'

INSERT INTO dbo.TicketStatus (Name,CreatedBy,Description)
VALUES
        ('New',         @User, 'Ticket was just created'),
        ('Pending',     @User, 'Ticket is currently pending approval'),
        ('In-Process',  @User, 'Ticket is currently being worked on.'),
        ('Resolved',    @User, 'Ticket has been resolved.'),
        ('Canceled',    @User, 'Ticket was canceled.')


INSERT INTO dbo.IssueSeverity (Name,Level,CreatedBy,Description)
VALUES
        ('Emergency',   'S1', @User, 'The issue is prevent all or most Users from using Platform.'),
        ('Critical',    'S2', @User, 'The System is adversely impacted.'),
        ('Major',       'S3', @User, 'The system experienced an error, short-term workaround available.'),
        ('Minor',       'S4', @User, 'Issue and requests without significant impact on system.'),
        ('Trivial',     'S5', @User, 'A condition might warrant action.')

INSERT INTO dbo.AppPermission (Name,CreatedBy,Description)
VALUES
        ('Admin',       @User, 'Access to all actions and processes'),
        ('User',        @User, 'Access to select number of actions and processes'),
        ('Requester',   @User, 'No access granted to')
        `