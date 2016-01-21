<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/" >
    <html>
      <style>
        body {
        padding: 20px;
        background-color: #ddd;
        font-size: 14px;
        text-align: left;
        }
        
        th, td {
        border: 1px solid black;
        padding: 10px;
        }

        th {
        background-color: #888;
        font-size: 1.2em;
        }
      </style>
      <head>
        <title>Students Web Page</title>
      </head>
      <body>
        <h1>Students</h1>
        <table>
          <tr>
            <th>Student</th>
            <th>Gender</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>E-mail</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty Nr:</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="/students/student">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="gender" />
              </td>
              <td>
                <xsl:value-of select="birth-date" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="specialty" />
              </td>
              <td>
                <xsl:value-of select="faculty-number" />
              </td>
              <td>
                <xsl:for-each select="taken-exams/exam">
                  <div>
                    <strong>
                      <xsl:value-of select="name"/>
                    </strong> /
                    tutor: <xsl:value-of select="tutor"/> /
                    score: <xsl:value-of select="score"/>
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>