/*
* MATLAB Compiler: 8.2 (R2021a)
* Date: Thu Jun  2 02:35:49 2022
* Arguments:
* "-B""macro_default""-W""dotnet:basic,Class1,4.0,private,version=1.0""-T""link:lib""-d""C
* :\Users\user\OneDrive\Documents\C#\final_project\basic\for_testing""-v""class{Class1:C:\
* Users\user\OneDrive\Documents\C#\final_project\basic.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace basicNative
{

  /// <summary>
  /// The Class1 class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\user\OneDrive\Documents\C#\final_project\basic.m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class Class1 : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Class1()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

		  int lastDelimiter = ctfFilePath.LastIndexOf(@"/");

	      if (lastDelimiter == -1)
		  {
		    lastDelimiter = ctfFilePath.LastIndexOf(@"\");
		  }

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "basic.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Class1 class.
    /// </summary>
    public Class1()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Class1()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    ///
    public void basic()
    {
      mcr.EvaluateFunction(0, "basic", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="gy_x">Input argument #1</param>
    ///
    public void basic(Object gy_x)
    {
      mcr.EvaluateFunction(0, "basic", gy_x);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="gy_x">Input argument #1</param>
    /// <param name="gy_y">Input argument #2</param>
    ///
    public void basic(Object gy_x, Object gy_y)
    {
      mcr.EvaluateFunction(0, "basic", gy_x, gy_y);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="gy_x">Input argument #1</param>
    /// <param name="gy_y">Input argument #2</param>
    /// <param name="gy_z">Input argument #3</param>
    ///
    public void basic(Object gy_x, Object gy_y, Object gy_z)
    {
      mcr.EvaluateFunction(0, "basic", gy_x, gy_y, gy_z);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] basic(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "basic", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="gy_x">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] basic(int numArgsOut, Object gy_x)
    {
      return mcr.EvaluateFunction(numArgsOut, "basic", gy_x);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="gy_x">Input argument #1</param>
    /// <param name="gy_y">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] basic(int numArgsOut, Object gy_x, Object gy_y)
    {
      return mcr.EvaluateFunction(numArgsOut, "basic", gy_x, gy_y);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the basic MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="gy_x">Input argument #1</param>
    /// <param name="gy_y">Input argument #2</param>
    /// <param name="gy_z">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] basic(int numArgsOut, Object gy_x, Object gy_y, Object gy_z)
    {
      return mcr.EvaluateFunction(numArgsOut, "basic", gy_x, gy_y, gy_z);
    }


    /// <summary>
    /// Provides an interface for the basic function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// xyz方向边长
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("basic", 3, 0, 0)]
    protected void basic(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("basic", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
