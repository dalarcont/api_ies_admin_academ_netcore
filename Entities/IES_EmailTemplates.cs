namespace IES_ADMIN_ACADEM_API.Entities
{
    public static class IES_EmailTemplates
    {
        /// IES_CSS 
        public static string IES_HTML_CSS()
        {
            return "<style>" +
                    ".uf_mail_default_template {" +
                    "	overflow: auto;" +
                    "	width: 100%;" +
                    "}" +
                    ".uf_mail_default_template table {" +
                    "	border: 1px solid #dededf;" +
                    "	height: 100%;" +
                    "	width: 100%;" +
                    "	table-layout: fixed;" +
                    "	border-collapse: collapse;" +
                    "	border-spacing: 1px;" +
                    "	text-align: center;" +
                    "	font-family: 'Trebuchet MS', Helvetica, sans-serif;" +
                    "}" +
                    ".uf_mail_default_template caption {" +
                    "	caption-side: top;" +
                    "	text-align: center;" +
                    "}" +
                    "" +
                    ".uf_mail_default_template th {" +
                    "	border: 1px solid #dededf;" +
                    "	background-color: #006bb3;" +
                    "	color: #ffffff;" +
                    "	padding: 5px;" +
                    "}" +
                    ".uf_mail_default_template td {" +
                    "	border: 1px solid #dededf;" +
                    "	background-color: #ffffff;" +
                    "	color: #000000;" +
                    "	padding: 5px;" +
                    "}" +
                    "td.issue_office {" +
                    "	font-size: 25px;" +
                    "}" +
                    "td.privacy {" +
                    "	font-size: 10px;" +
                    "}" +
                    "td.subject {" +
                    "	font-size: 18px;" +
                    "}" +
                    "td.content {" +
                    "	font-size: 14px;" +
                    "}" +
                    "</style>";
        }
        public static string IES_DEV_InfoMail(string destination)
        {
            return "<style>" +
                 "    div.PWPostnewuser {" +
                 "      border: 1px solid #1C6EA4;" +
                 "      background-color: #EEEEEE;" +
                 "      width: 565px;" +
                 "      text-align: center;" +
                 "      border-collapse: collapse;" +
                 "    }" +
                 "    .divTable.PWPostnewuser .divTableCell, .divTable.PWPostnewuser .divTableHead {" +
                 "      border: 1px solid #AAAAAA;" +
                 "      padding: 3px 2px;" +
                 "    }" +
                 "    .divTable.PWPostnewuser .divTableBody .divTableCell {" +
                 "      font-size: 13px;" +
                 "    }" +
                 "    .divTable.PWPostnewuser .divTableRow:nth-child(even) {" +
                 "      background: #D0E4F5;" +
                 "    }" +
                 "    .divTable.PWPostnewuser .divTableHeading {" +
                 "      background: #1C6EA4;" +
                 "      background: -moz-linear-gradient(top, #5592bb 0%, #327cad 66%, #1C6EA4 100%);" +
                 "      background: -webkit-linear-gradient(top, #5592bb 0%, #327cad 66%, #1C6EA4 100%);" +
                 "      background: linear-gradient(to bottom, #5592bb 0%, #327cad 66%, #1C6EA4 100%);" +
                 "      border-bottom: 2px solid #444444;" +
                 "    }" +
                 "    .divTable.PWPostnewuser .divTableHeading .divTableHead {" +
                 "      font-size: 15px;" +
                 "      font-weight: bold;" +
                 "      color: #FFFFFF;" +
                 "      border-left: 2px solid #D0E4F5;" +
                 "    }" +
                 "    .divTable.PWPostnewuser .divTableHeading .divTableHead:first-child {" +
                 "      border-left: none;" +
                 "    }" +
                 "    " +
                 "    .PWPostnewuser .tableFootStyle {" +
                 "      font-size: 14px;" +
                 "    }" +
                 "    .PWPostnewuser .tableFootStyle .links {" +
                 "         text-align: right;" +
                 "    }" +
                 "    .PWPostnewuser .tableFootStyle .links a{" +
                 "      display: inline-block;" +
                 "      background: #1C6EA4;" +
                 "      color: #FFFFFF;" +
                 "      padding: 2px 8px;" +
                 "      border-radius: 5px;" +
                 "    }" +
                 "    .PWPostnewuser.outerTableFooter {" +
                 "      border-top: none;" +
                 "    }" +
                 "    .PWPostnewuser.outerTableFooter .tableFootStyle {" +
                 "      padding: 3px 5px; " +
                 "    }" +
                 "    .divTable{ display: table; }" +
                 "    .divTableRow { display: table-row; }" +
                 "    .divTableHeading { display: table-header-group;}" +
                 "    .divTableCell, .divTableHead { display: table-cell;}" +
                 "    .divTableHeading { display: table-header-group;}" +
                 "    .divTableFoot { display: table-footer-group;}" +
                 "    .divTableBody { display: table-row-group;}" +
                 "    </style>" +
                 "    <div class='divTable PWPostnewuser'>" +
                 "    <div class='divTableHeading'>" +
                 "    <div class='divTableRow'>" +
                 "    <div class='divTableHead'><?xml version='1.0' encoding='UTF-8' standalone='no'?>" +
                 "    <!DOCTYPE svg PUBLIC '-//W3C//DTD SVG 1.1//EN' 'http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd'>" +
                 "    <svg version='1.1' id='Layer_1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px' width='32px' height='32px' viewBox='0 0 16 16' enable-background='new 0 0 16 16' xml:space='preserve'>  <image id='image0' width='16' height='16' x='0' y='0'" +
                 "        xlink:href='data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAABGdBTUEAALGPC/xhBQAAACBjSFJN" +
                 "    AAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAApVBMVEUSTKcPSaENSKEOSKIN" +
                 "    R6IOS6UOR6MOSqYNR6EQSaIzZLA6abMYT6U5aLIiV6k3Z7IyY7Df5vKHpNDO2uxFcrfl6/Xi6fTf" +
                 "    5/MbUqbAz+Z0lcmJpdH09vu0xuI9a7Tc5PEYUKXn7faovd3L1+s1ZbDG1OnE0ugbUqfh6PNNd7ov" +
                 "    Ya6vwuDQ3O2Ysde6yuTe5vIkWKp7msxCcLYfVKhHc7cpXKz///+b2HPvAAAACHRSTlNG3P3d/kfe" +
                 "    SJjPmjcAAAABYktHRDZHv4jRAAAAB3RJTUUH5QMRARkPLyW0BQAAAIhJREFUGNNlj+kSgjAMhLcF" +
                 "    ZfGsB96Kihd4Vuv7v5oDKENlf2QyXzLZDSAkC0kBCFpyIG3ggn+C32i2sq7NDtn1oXr9wTAFAUfk" +
                 "    eAI15Wyeg8VyFa6hNttoV2zsCXU45tcCnsiYSM7f8xdeb/H9kdkmWuvnzzYtL2PMuwysYJXoledq" +
                 "    dbc0d7wPhe4M3pKgs/MAAAAldEVYdGRhdGU6Y3JlYXRlADIwMjEtMDMtMTdUMDE6MjU6MTUrMDM6" +
                 "    MDAtSZx6AAAAJXRFWHRkYXRlOm1vZGlmeQAyMDIxLTAzLTE3VDAxOjI1OjE1KzAzOjAwXBQkxgAA" +
                 "    AABJRU5ErkJggg==' />" +
                 "    </svg><br>PWPost</div>" +
                 "    </div>" +
                 "    </div>" +
                 "    <div class='divTableBody'>" +
                 "    <div class='divTableRow'>" +
                 "    <div class='divTableCell'><br>Correo Informativo Desarrollo Informático<br></div>" +
                 "    </div>" +
                 "    <div class='divTableRow'>" +
                 "    <div class='divTableCell'><br>Recibes este correo con el fin de que se están ejecutando pruebas<br>" +
                 "en las cuales se evidencia que se necesita un envío de correo a tu dirección y por eso recibes esta comunicación.<br>Puedes borrarla.</div>" +
                 "    </div>" +
                 "    <div class='divTableRow'>" +
                 "    <div class='divTableCell'><br>CORREO INFORMATIVO ÚNICAMENTE<br></div>" +
                 "    </div>" +
                 "    <div class='divTableRow'>" +
                 "    <div class='divTableCell'><br>Correo objetivo:" + destination + "<br />Si usted no es el destinatario final y se trata de una equivocaci&oacute;n, por favor hacer caso omiso de este mensaje y eliminarlo.<br /><br />Universidad Falsa<br />2023</div>" +
                 "    </div>" +
                 "    </div>" +
                 "    </div>";
        }

        public static string IES_DEV_WELCOME_NEW_USER(string[] msgContent)
        {
            return string.Concat(IES_HTML_CSS(),
                "<div class='uf_mail_default_template' role='region' tabindex='0'>" +
                "<table>" +
                "    <thead>" +
                "        <tr>" +
                "            <th>UF<br>Universidad Falsa</th>" +
                "        </tr>" +
                "    </thead>" +
                "    <tbody>" +
                "        <tr>" +
                "            <td class='issue_office'>Oficina de Registro y Control</td>" +
                "        </tr>" +
                "        <tr>" +
                "            <td class='subject'>"+msgContent.ElementAt(0)+"</td>" +
                "        </tr>" +
                "        <tr>" +
                "            <td class='content'><br>Confirmamos que hemos realizado tu registro en nuestro sistema de información.<br>" +
                "               A partir del recibo de esta comunicación ya te encuentras registrado en la Universidad Falsa.<br><br>" +
                "               Confirmamos tus datos básicos: <br><br>" +
                "               <b>Identificación: "+msgContent.ElementAt(1)+"</b><br>" +
                "               <b>Nombre de usuario: "+msgContent.ElementAt(2)+"</b><br>" +
                "               <b>Nombre completo: "+msgContent.ElementAt(3)+"</b> <br><br></td>" +
                "        </tr>" +
                "        <tr>" +
                "            <td class='privacy'>Este correo es informativo.<br>Por favor no responder<br>" +
                "                   Si usted no es el destinatario final de este mensaje por favor haga caso omiso de esta comunicación.<br>" +
                "               Universidad Falsa<br>2024" +
                "         </td>" +
                "        </tr>" +
                "    </tbody>" +
                "</table>" + 
                "</div>");
        }
    }
}
