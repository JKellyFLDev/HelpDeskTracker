/** HEADER
===============================================================================
NAME: Glenn Weber
DESCRIPTION: Returns the count of all tickets by day.
NOTES:
    * Still needs to be tested once we have data (2020-11-20)
HISTORY:
-------------------------------------------------------------------------------
[2020-11-20] - [gweber] - Initial Creation
===============================================================================
END HEADER **/

--EXEC [dbo].[GetAllTicketCountsByDay]

USE [HelpDeskData]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllTicketsCountsByDay]
AS
    SELECT
        CAST(T.DateOpen AS DATE) AS 'DateOpened',
        DATENAME(dw,T.DateOpen) AS 'DayOfTheWeek',
        COUNT(DATENAME(dw,T.DateOpen)) AS 'Count'
    FROM dbo.Tickets T
    GROUP BY
        CAST(T.DateOpen AS DATE),
        DATENAME(dw,T.DateOpen)
GO
