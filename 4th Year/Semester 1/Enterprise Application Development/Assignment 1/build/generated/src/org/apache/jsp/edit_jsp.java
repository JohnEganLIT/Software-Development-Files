package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class edit_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final JspFactory _jspxFactory = JspFactory.getDefaultFactory();

  private static java.util.List<String> _jspx_dependants;

  private org.glassfish.jsp.api.ResourceInjector _jspx_resourceInjector;

  public java.util.List<String> getDependants() {
    return _jspx_dependants;
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;

    try {
      response.setContentType("text/html;charset=UTF-8");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;
      _jspx_resourceInjector = (org.glassfish.jsp.api.ResourceInjector) application.getAttribute("com.sun.appserv.jsp.resource.injector");

      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("<LINK REL=STYLESHEET HREF=\"resources/css/style.css\" TYPE=\"text/css\">\n");
      out.write("\n");
      out.write("\n");
      out.write("<html>\n");
      out.write("    <head><title>Edit a Route</title></head>\n");
      out.write("\n");
      out.write("    <body>\n");
      out.write("        <h1>Edit  </h1> <br>\n");
      out.write("   \n");
      out.write("    <br>\n");
      out.write("    \n");
      out.write("    <form action=\"\">\n");
      out.write("        \n");
      out.write("        <table width =\"500\" border=\"0\">\n");
      out.write("            <tbody>\n");
      out.write("                 <tr>\n");
      out.write("                    <td>Code</td>\n");
      out.write("                    <td><input type=\"text\" name=\"code\" value=\"\" readonly /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>City</td>\n");
      out.write("                    <td><input type=\"text\" name=\"city\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Airport</td>\n");
      out.write("                    <td><input type=\"text\" name=\"airport\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                \n");
      out.write("                    <td>Q1 Passengers</td>\n");
      out.write("                    <td><input type=\"text\" name=\"q1\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Q2 Passengers</td>\n");
      out.write("                    <td><input type=\"text\" name=\"q2\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Q3 Passengers</td>\n");
      out.write("                    <td><input type=\"text\" name=\"q3\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Q4 Passengers</td>\n");
      out.write("                    <td><input type=\"text\" name=\"q4\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                \n");
      out.write("            </tbody>\n");
      out.write("        </table>\n");
      out.write("                <input type=\"submit\" value=\"Submit\" />  <input type=\"submit\" value=\"Go Back\" />\n");
      out.write("    </form>\n");
      out.write("    \n");
      out.write("                  \n");
      out.write("\n");
      out.write("    </body>\n");
      out.write("</html>\n");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          out.clearBuffer();
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
        else throw new ServletException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
