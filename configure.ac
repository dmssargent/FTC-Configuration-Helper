#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT(FTC-Config-Helper, 0.1, admin@mhsrobotics.peoplepluscomputers.com)
AM_INIT_AUTOMAKE([])

# Checks for programs.
AC_PROG_INSTALL
AC_PROG_CC
AC_PROG_CXX

AC_CHECK_CLASSPATH
AX_PROG_JAVAC
AX_PROG_JAVA

AC_CHECK_PROG([git],[git],[yes],[no])
AM_CONDITIONAL([FOUND_GIT], [test "x$git" = xyes])
AM_COND_IF([FOUND_GIT],,[AC_MSG_WARN([Cannot find 'git.' It is recommended to install it.])])

AC_CHECK_PROG([brctl],[brctl],[yes],[no])
AM_CONDITIONAL([FOUND_BRIG_UTILS], [test "x$git" = xyes])
AM_COND_IF([FOUND_BRIG_UTILS],,[AC_MSG_ERROR([Cannot find 'brctl.' It is necessary to install bridge-utils. Try 'sudo apt-get install bridge-utils' for Debian or Ubuntu.])])

# Checks for libraries.

# Checks for header files.

# Checks for typedefs, structures, and compiler characteristics.

# Checks for library functions.

AC_CONFIG_FILES([Makefile])
AC_OUTPUT
