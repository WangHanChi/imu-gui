/*
* MATLAB Compiler: 8.4 (R2022a)
* Date: Fri Jun  3 17:01:48 2022
* Arguments:
* "-B""macro_default""-W""dotnet:c130,Airplane3D,4.0,private,version=1.0""-T""link:lib""-d
* ""C:\Users\lin\Downloads\final_project\新增資料夾\c130\for_testing""-v""class{Airpl
* ane3D:C:\Users\lin\Downloads\c130_v1\c130.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace c130
{

  /// <summary>
  /// The Airplane3D class provides a CLS compliant, MWArray interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\lin\Downloads\c130_v1\c130.m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class Airplane3D : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Airplane3D()
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

          string ctfFileName = "c130.ctf";

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
    /// Constructs a new instance of the Airplane3D class.
    /// </summary>
    public Airplane3D()
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
    ~Airplane3D()
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
    /// Provides a single output, 0-input MWArrayinterface to the c130 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// C130 draws a simple 3D airplane loosely modelled after a Lockheed C-130.
    /// c130 Syntax 
    /// c130 
    /// c130(x,y,z)
    /// c130(...,'roll',RollDegrees)
    /// c130(...,'pitch',PitchDegrees)
    /// c130(...,'yaw',YawDegrees)
    /// c130(...,'color',AirplaneColor)
    /// c130(...,'fuselage',FuseLageColor)
    /// c130(...,'wing',WingColor)
    /// c130(...,'tailwing',TailwingColor)
    /// c130(...,'fin',FinColor)
    /// c130(...,'prop',PropellerColor)
    /// c130(...,'scale',SizeScaleFactor)
    /// c130(...,'z',ZScaleFactor)
    /// c130(...,'linestyle','LineStyle')
    /// c130(...,'linecolor',LineColor)
    /// h = c130(...)
    /// c130 Description
    /// c130 draws a 3D airplane.
    /// c130(x,y,z) draws an airplane centered approximately at the location
    /// given by x,y,z, where x, y, and z must be scalar values. 
    /// c130(...,'roll',RollDegrees) specifies roll of the aircraft in degrees
    /// relative to the approximate center of gravity of the aircraft. 
    /// c130(...,'pitch',PitchDegrees) specifies pitch of the aircraft in
    /// degrees.
    /// c130(...,'yaw',YawDegrees) specifies yaw of the aircraft in degrees in
    /// the global coordinate system. The xyz2rpy function may help with
    /// determining appropriate yaw values. 
    /// c130(...,'color',AirplaneColor) specifies a color of all surfaces of
    /// the plane.  Color may be given by Matlab color name (e.g., 'red'),
    /// Matlab color abbreviation (e.g., 'r'), or RGB value (e.g., [1 0 0]).
    /// The 'color' option may be paired with options for specifying colors of
    /// specific parts of the plane.  For example, c130('color','b','wing',y)
    /// creates a blue airplane with yellow wings. Default color is gray. 
    /// c130(...,'fuselage',FuselageColor) specifies fuselage color. 
    /// c130(...,'wing',WingColor) specifies wing color. 
    /// c130(...,'tailwing',TailwingColor) specifies color of horizontal
    /// stabilizer wings at the tail of the plane. 
    /// c130(...,'fin',FinColor) specifies color of the vertical stabilizer fin
    /// at the tail of the plane. 
    /// c130(...,'prop',PropellerColor) specifies propeller color. 
    /// c130(...,'scale',SizeScaleFactor) scales dimensions of the plane by
    /// some scalar factor. By default, c130 draws an airplane with dimensions
    /// which approximately match the dimensions C-130 airplane in meters.  If you'd 
    /// like to draw a C-130 in dimensions of feet, try c130('scale',3.281). 
    /// c130(...,'z',ZScaleFactor) scales only vertical dimensions by some
    /// scalar value.  This may be useful if you're animating an airplane in a
    /// coordinate system where the vertical dimension is stretched to show
    /// relief.  If your axes are not equal, consider a ZScaleFactor given by
    /// the ratio of (xlim(2)-xlim(1))/(zlim(2)-zlim(1)). 
    /// c130(...,'linestyle','LineStyle') specifies style of the lines
    /// connecting surface vertices. Default is '-', but can be set to any
    /// valid linestyle, including 'none' to show a smooth surface. 
    /// c130(...,'linecolor',LineColor) specifies edge color of lines
    /// connecting surface verticies. Default line color is black. 
    /// h = c130(...) returns handles of the 13 surface objects created by
    /// c130. Handles correspond to the following: 
    /// * h(1): main fuselage. 
    /// * h(2): nose. 
    /// * h(3): tail section of fuselage. 
    /// * h(4): top side of main wing. 
    /// * h(5): under side of main wing. 
    /// * h(6): top side of tail wing. 
    /// * h(7): under side of tail wing. 
    /// * h(8): right side of fin. 
    /// * h(9): left side of fin. 
    /// * h(10:13): propellers.
    /// Author Info
    /// Chad A. Greene of the University of Texas Institute for Geophysics (UTIG)
    /// wrote this on Saturday, September 27, 2014. Feel free to visit Chad on
    /// over at http://www.chadagreene.com. 
    /// See also xyz2rpy
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray c130()
    {
      return mcr.EvaluateFunction("c130", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the c130 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// C130 draws a simple 3D airplane loosely modelled after a Lockheed C-130.
    /// c130 Syntax 
    /// c130 
    /// c130(x,y,z)
    /// c130(...,'roll',RollDegrees)
    /// c130(...,'pitch',PitchDegrees)
    /// c130(...,'yaw',YawDegrees)
    /// c130(...,'color',AirplaneColor)
    /// c130(...,'fuselage',FuseLageColor)
    /// c130(...,'wing',WingColor)
    /// c130(...,'tailwing',TailwingColor)
    /// c130(...,'fin',FinColor)
    /// c130(...,'prop',PropellerColor)
    /// c130(...,'scale',SizeScaleFactor)
    /// c130(...,'z',ZScaleFactor)
    /// c130(...,'linestyle','LineStyle')
    /// c130(...,'linecolor',LineColor)
    /// h = c130(...)
    /// c130 Description
    /// c130 draws a 3D airplane.
    /// c130(x,y,z) draws an airplane centered approximately at the location
    /// given by x,y,z, where x, y, and z must be scalar values. 
    /// c130(...,'roll',RollDegrees) specifies roll of the aircraft in degrees
    /// relative to the approximate center of gravity of the aircraft. 
    /// c130(...,'pitch',PitchDegrees) specifies pitch of the aircraft in
    /// degrees.
    /// c130(...,'yaw',YawDegrees) specifies yaw of the aircraft in degrees in
    /// the global coordinate system. The xyz2rpy function may help with
    /// determining appropriate yaw values. 
    /// c130(...,'color',AirplaneColor) specifies a color of all surfaces of
    /// the plane.  Color may be given by Matlab color name (e.g., 'red'),
    /// Matlab color abbreviation (e.g., 'r'), or RGB value (e.g., [1 0 0]).
    /// The 'color' option may be paired with options for specifying colors of
    /// specific parts of the plane.  For example, c130('color','b','wing',y)
    /// creates a blue airplane with yellow wings. Default color is gray. 
    /// c130(...,'fuselage',FuselageColor) specifies fuselage color. 
    /// c130(...,'wing',WingColor) specifies wing color. 
    /// c130(...,'tailwing',TailwingColor) specifies color of horizontal
    /// stabilizer wings at the tail of the plane. 
    /// c130(...,'fin',FinColor) specifies color of the vertical stabilizer fin
    /// at the tail of the plane. 
    /// c130(...,'prop',PropellerColor) specifies propeller color. 
    /// c130(...,'scale',SizeScaleFactor) scales dimensions of the plane by
    /// some scalar factor. By default, c130 draws an airplane with dimensions
    /// which approximately match the dimensions C-130 airplane in meters.  If you'd 
    /// like to draw a C-130 in dimensions of feet, try c130('scale',3.281). 
    /// c130(...,'z',ZScaleFactor) scales only vertical dimensions by some
    /// scalar value.  This may be useful if you're animating an airplane in a
    /// coordinate system where the vertical dimension is stretched to show
    /// relief.  If your axes are not equal, consider a ZScaleFactor given by
    /// the ratio of (xlim(2)-xlim(1))/(zlim(2)-zlim(1)). 
    /// c130(...,'linestyle','LineStyle') specifies style of the lines
    /// connecting surface vertices. Default is '-', but can be set to any
    /// valid linestyle, including 'none' to show a smooth surface. 
    /// c130(...,'linecolor',LineColor) specifies edge color of lines
    /// connecting surface verticies. Default line color is black. 
    /// h = c130(...) returns handles of the 13 surface objects created by
    /// c130. Handles correspond to the following: 
    /// * h(1): main fuselage. 
    /// * h(2): nose. 
    /// * h(3): tail section of fuselage. 
    /// * h(4): top side of main wing. 
    /// * h(5): under side of main wing. 
    /// * h(6): top side of tail wing. 
    /// * h(7): under side of tail wing. 
    /// * h(8): right side of fin. 
    /// * h(9): left side of fin. 
    /// * h(10:13): propellers.
    /// Author Info
    /// Chad A. Greene of the University of Texas Institute for Geophysics (UTIG)
    /// wrote this on Saturday, September 27, 2014. Feel free to visit Chad on
    /// over at http://www.chadagreene.com. 
    /// See also xyz2rpy
    /// </remarks>
    /// <param name="varargin">Array of MWArrays representing the input arguments 1
    /// through varargin.length</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray c130(params MWArray[] varargin)
    {
      return mcr.EvaluateFunction("c130", varargin);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the c130 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// C130 draws a simple 3D airplane loosely modelled after a Lockheed C-130.
    /// c130 Syntax 
    /// c130 
    /// c130(x,y,z)
    /// c130(...,'roll',RollDegrees)
    /// c130(...,'pitch',PitchDegrees)
    /// c130(...,'yaw',YawDegrees)
    /// c130(...,'color',AirplaneColor)
    /// c130(...,'fuselage',FuseLageColor)
    /// c130(...,'wing',WingColor)
    /// c130(...,'tailwing',TailwingColor)
    /// c130(...,'fin',FinColor)
    /// c130(...,'prop',PropellerColor)
    /// c130(...,'scale',SizeScaleFactor)
    /// c130(...,'z',ZScaleFactor)
    /// c130(...,'linestyle','LineStyle')
    /// c130(...,'linecolor',LineColor)
    /// h = c130(...)
    /// c130 Description
    /// c130 draws a 3D airplane.
    /// c130(x,y,z) draws an airplane centered approximately at the location
    /// given by x,y,z, where x, y, and z must be scalar values. 
    /// c130(...,'roll',RollDegrees) specifies roll of the aircraft in degrees
    /// relative to the approximate center of gravity of the aircraft. 
    /// c130(...,'pitch',PitchDegrees) specifies pitch of the aircraft in
    /// degrees.
    /// c130(...,'yaw',YawDegrees) specifies yaw of the aircraft in degrees in
    /// the global coordinate system. The xyz2rpy function may help with
    /// determining appropriate yaw values. 
    /// c130(...,'color',AirplaneColor) specifies a color of all surfaces of
    /// the plane.  Color may be given by Matlab color name (e.g., 'red'),
    /// Matlab color abbreviation (e.g., 'r'), or RGB value (e.g., [1 0 0]).
    /// The 'color' option may be paired with options for specifying colors of
    /// specific parts of the plane.  For example, c130('color','b','wing',y)
    /// creates a blue airplane with yellow wings. Default color is gray. 
    /// c130(...,'fuselage',FuselageColor) specifies fuselage color. 
    /// c130(...,'wing',WingColor) specifies wing color. 
    /// c130(...,'tailwing',TailwingColor) specifies color of horizontal
    /// stabilizer wings at the tail of the plane. 
    /// c130(...,'fin',FinColor) specifies color of the vertical stabilizer fin
    /// at the tail of the plane. 
    /// c130(...,'prop',PropellerColor) specifies propeller color. 
    /// c130(...,'scale',SizeScaleFactor) scales dimensions of the plane by
    /// some scalar factor. By default, c130 draws an airplane with dimensions
    /// which approximately match the dimensions C-130 airplane in meters.  If you'd 
    /// like to draw a C-130 in dimensions of feet, try c130('scale',3.281). 
    /// c130(...,'z',ZScaleFactor) scales only vertical dimensions by some
    /// scalar value.  This may be useful if you're animating an airplane in a
    /// coordinate system where the vertical dimension is stretched to show
    /// relief.  If your axes are not equal, consider a ZScaleFactor given by
    /// the ratio of (xlim(2)-xlim(1))/(zlim(2)-zlim(1)). 
    /// c130(...,'linestyle','LineStyle') specifies style of the lines
    /// connecting surface vertices. Default is '-', but can be set to any
    /// valid linestyle, including 'none' to show a smooth surface. 
    /// c130(...,'linecolor',LineColor) specifies edge color of lines
    /// connecting surface verticies. Default line color is black. 
    /// h = c130(...) returns handles of the 13 surface objects created by
    /// c130. Handles correspond to the following: 
    /// * h(1): main fuselage. 
    /// * h(2): nose. 
    /// * h(3): tail section of fuselage. 
    /// * h(4): top side of main wing. 
    /// * h(5): under side of main wing. 
    /// * h(6): top side of tail wing. 
    /// * h(7): under side of tail wing. 
    /// * h(8): right side of fin. 
    /// * h(9): left side of fin. 
    /// * h(10:13): propellers.
    /// Author Info
    /// Chad A. Greene of the University of Texas Institute for Geophysics (UTIG)
    /// wrote this on Saturday, September 27, 2014. Feel free to visit Chad on
    /// over at http://www.chadagreene.com. 
    /// See also xyz2rpy
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] c130(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "c130", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the c130 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// C130 draws a simple 3D airplane loosely modelled after a Lockheed C-130.
    /// c130 Syntax 
    /// c130 
    /// c130(x,y,z)
    /// c130(...,'roll',RollDegrees)
    /// c130(...,'pitch',PitchDegrees)
    /// c130(...,'yaw',YawDegrees)
    /// c130(...,'color',AirplaneColor)
    /// c130(...,'fuselage',FuseLageColor)
    /// c130(...,'wing',WingColor)
    /// c130(...,'tailwing',TailwingColor)
    /// c130(...,'fin',FinColor)
    /// c130(...,'prop',PropellerColor)
    /// c130(...,'scale',SizeScaleFactor)
    /// c130(...,'z',ZScaleFactor)
    /// c130(...,'linestyle','LineStyle')
    /// c130(...,'linecolor',LineColor)
    /// h = c130(...)
    /// c130 Description
    /// c130 draws a 3D airplane.
    /// c130(x,y,z) draws an airplane centered approximately at the location
    /// given by x,y,z, where x, y, and z must be scalar values. 
    /// c130(...,'roll',RollDegrees) specifies roll of the aircraft in degrees
    /// relative to the approximate center of gravity of the aircraft. 
    /// c130(...,'pitch',PitchDegrees) specifies pitch of the aircraft in
    /// degrees.
    /// c130(...,'yaw',YawDegrees) specifies yaw of the aircraft in degrees in
    /// the global coordinate system. The xyz2rpy function may help with
    /// determining appropriate yaw values. 
    /// c130(...,'color',AirplaneColor) specifies a color of all surfaces of
    /// the plane.  Color may be given by Matlab color name (e.g., 'red'),
    /// Matlab color abbreviation (e.g., 'r'), or RGB value (e.g., [1 0 0]).
    /// The 'color' option may be paired with options for specifying colors of
    /// specific parts of the plane.  For example, c130('color','b','wing',y)
    /// creates a blue airplane with yellow wings. Default color is gray. 
    /// c130(...,'fuselage',FuselageColor) specifies fuselage color. 
    /// c130(...,'wing',WingColor) specifies wing color. 
    /// c130(...,'tailwing',TailwingColor) specifies color of horizontal
    /// stabilizer wings at the tail of the plane. 
    /// c130(...,'fin',FinColor) specifies color of the vertical stabilizer fin
    /// at the tail of the plane. 
    /// c130(...,'prop',PropellerColor) specifies propeller color. 
    /// c130(...,'scale',SizeScaleFactor) scales dimensions of the plane by
    /// some scalar factor. By default, c130 draws an airplane with dimensions
    /// which approximately match the dimensions C-130 airplane in meters.  If you'd 
    /// like to draw a C-130 in dimensions of feet, try c130('scale',3.281). 
    /// c130(...,'z',ZScaleFactor) scales only vertical dimensions by some
    /// scalar value.  This may be useful if you're animating an airplane in a
    /// coordinate system where the vertical dimension is stretched to show
    /// relief.  If your axes are not equal, consider a ZScaleFactor given by
    /// the ratio of (xlim(2)-xlim(1))/(zlim(2)-zlim(1)). 
    /// c130(...,'linestyle','LineStyle') specifies style of the lines
    /// connecting surface vertices. Default is '-', but can be set to any
    /// valid linestyle, including 'none' to show a smooth surface. 
    /// c130(...,'linecolor',LineColor) specifies edge color of lines
    /// connecting surface verticies. Default line color is black. 
    /// h = c130(...) returns handles of the 13 surface objects created by
    /// c130. Handles correspond to the following: 
    /// * h(1): main fuselage. 
    /// * h(2): nose. 
    /// * h(3): tail section of fuselage. 
    /// * h(4): top side of main wing. 
    /// * h(5): under side of main wing. 
    /// * h(6): top side of tail wing. 
    /// * h(7): under side of tail wing. 
    /// * h(8): right side of fin. 
    /// * h(9): left side of fin. 
    /// * h(10:13): propellers.
    /// Author Info
    /// Chad A. Greene of the University of Texas Institute for Geophysics (UTIG)
    /// wrote this on Saturday, September 27, 2014. Feel free to visit Chad on
    /// over at http://www.chadagreene.com. 
    /// See also xyz2rpy
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="varargin">Array of MWArrays representing the input arguments 1
    /// through varargin.length</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] c130(int numArgsOut, params MWArray[] varargin)
    {
      return mcr.EvaluateFunction(numArgsOut, "c130", varargin);
    }


    /// <summary>
    /// Provides an interface for the c130 function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// C130 draws a simple 3D airplane loosely modelled after a Lockheed C-130.
    /// c130 Syntax 
    /// c130 
    /// c130(x,y,z)
    /// c130(...,'roll',RollDegrees)
    /// c130(...,'pitch',PitchDegrees)
    /// c130(...,'yaw',YawDegrees)
    /// c130(...,'color',AirplaneColor)
    /// c130(...,'fuselage',FuseLageColor)
    /// c130(...,'wing',WingColor)
    /// c130(...,'tailwing',TailwingColor)
    /// c130(...,'fin',FinColor)
    /// c130(...,'prop',PropellerColor)
    /// c130(...,'scale',SizeScaleFactor)
    /// c130(...,'z',ZScaleFactor)
    /// c130(...,'linestyle','LineStyle')
    /// c130(...,'linecolor',LineColor)
    /// h = c130(...)
    /// c130 Description
    /// c130 draws a 3D airplane.
    /// c130(x,y,z) draws an airplane centered approximately at the location
    /// given by x,y,z, where x, y, and z must be scalar values. 
    /// c130(...,'roll',RollDegrees) specifies roll of the aircraft in degrees
    /// relative to the approximate center of gravity of the aircraft. 
    /// c130(...,'pitch',PitchDegrees) specifies pitch of the aircraft in
    /// degrees.
    /// c130(...,'yaw',YawDegrees) specifies yaw of the aircraft in degrees in
    /// the global coordinate system. The xyz2rpy function may help with
    /// determining appropriate yaw values. 
    /// c130(...,'color',AirplaneColor) specifies a color of all surfaces of
    /// the plane.  Color may be given by Matlab color name (e.g., 'red'),
    /// Matlab color abbreviation (e.g., 'r'), or RGB value (e.g., [1 0 0]).
    /// The 'color' option may be paired with options for specifying colors of
    /// specific parts of the plane.  For example, c130('color','b','wing',y)
    /// creates a blue airplane with yellow wings. Default color is gray. 
    /// c130(...,'fuselage',FuselageColor) specifies fuselage color. 
    /// c130(...,'wing',WingColor) specifies wing color. 
    /// c130(...,'tailwing',TailwingColor) specifies color of horizontal
    /// stabilizer wings at the tail of the plane. 
    /// c130(...,'fin',FinColor) specifies color of the vertical stabilizer fin
    /// at the tail of the plane. 
    /// c130(...,'prop',PropellerColor) specifies propeller color. 
    /// c130(...,'scale',SizeScaleFactor) scales dimensions of the plane by
    /// some scalar factor. By default, c130 draws an airplane with dimensions
    /// which approximately match the dimensions C-130 airplane in meters.  If you'd 
    /// like to draw a C-130 in dimensions of feet, try c130('scale',3.281). 
    /// c130(...,'z',ZScaleFactor) scales only vertical dimensions by some
    /// scalar value.  This may be useful if you're animating an airplane in a
    /// coordinate system where the vertical dimension is stretched to show
    /// relief.  If your axes are not equal, consider a ZScaleFactor given by
    /// the ratio of (xlim(2)-xlim(1))/(zlim(2)-zlim(1)). 
    /// c130(...,'linestyle','LineStyle') specifies style of the lines
    /// connecting surface vertices. Default is '-', but can be set to any
    /// valid linestyle, including 'none' to show a smooth surface. 
    /// c130(...,'linecolor',LineColor) specifies edge color of lines
    /// connecting surface verticies. Default line color is black. 
    /// h = c130(...) returns handles of the 13 surface objects created by
    /// c130. Handles correspond to the following: 
    /// * h(1): main fuselage. 
    /// * h(2): nose. 
    /// * h(3): tail section of fuselage. 
    /// * h(4): top side of main wing. 
    /// * h(5): under side of main wing. 
    /// * h(6): top side of tail wing. 
    /// * h(7): under side of tail wing. 
    /// * h(8): right side of fin. 
    /// * h(9): left side of fin. 
    /// * h(10:13): propellers.
    /// Author Info
    /// Chad A. Greene of the University of Texas Institute for Geophysics (UTIG)
    /// wrote this on Saturday, September 27, 2014. Feel free to visit Chad on
    /// over at http://www.chadagreene.com. 
    /// See also xyz2rpy
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void c130(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("c130", numArgsOut, ref argsOut, argsIn);
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
