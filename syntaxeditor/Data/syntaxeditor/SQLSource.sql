/* Variable Names Example: */

FUNCTION GetEmplInfo ( p_empl_rcd  IN VARCHAR2
,                      p_emplid    IN VARCHAR2)
RETURN BOOLEAN IS
--
DECLARE 
  CURSOR c_empl IS
    SELECT  pd.emplid
    ,	pd.empl_rcd#
    ,	ba.acct_cd
    FROM  ps_personal_data    pd
    ,     ps_budget_actuals  ba
    WHERE   pd.emplid = p_emplid
      AND  pd.empl_rcd# = p_empl_rcd
      AND  pd.emplid = ba.emplid
      AND  pd.empl_rcd# = ba.empl_rcd#;
    Emp_rec   c_empl%ROWTYPE;

    v_acct_cd          VARCHAR2(20)                      -- holds the account cd to be returned
    v_ok               BOOLEAN := TRUE     
    v_empl_rcd         ps_personal_data.empl_rcd#%TYPE   -- holds the empl_rcd
    e_employee_problem EXCEPTIONS;                       -- exceptions to indicate problem with employee record
--
BEGIN
  FOR  emp_rec IN c_empl

  LOOP
    IF emp_rec.empl_rcd# > 0 THEN
      ...
    ELSE
      ...
    END IF;
  END LOOP;
  RETURN v_ok;
EXCEPTIONS
  WHEN OTHERS THEN
         RETURN FALSE;
END;

/* Capitalization Example: */

FUNCTION GetEmplInfo ( p_empl_rcd  IN VARCHAR2
,                      p_emplid    IN VARCHAR2)
RETURN VARCHAR2   IS

DECLARE 
  v_acct_cd   VARCHAR2   -- holds the account cd to be returned
  v_emplid    VARCHAR2   -- holds the emplid 
  v_empl_rcd  VARCHAR2   -- holds the empl_rcd
--
BEGIN
  SELECT pd.emplid
  ,      pd.empl_rcd#
  ,      ba.acct_cd
  INTO   v_emplid
  ,      v_empl_rcd
  ,      v_acct_cd
  FROM   ps_personal_data   pd
  ,      ps_budget_actuals  ba
  WHERE  pd.emplid = p_emplid
    AND  pd.empl_rcd# = p_empl_rcd
    AND  pd.emplid = ba.emplid
    AND  pd.empl_rcd# = ba.empl_rcd#;
  RETURN v_acct_cd;
EXCEPTIONS
  WHEN OTHERS THEN
    RETURN null;
END;

/* Indentation Examples: */

/* Indentation Example 1: */
  SELECT   pd.emplid
  ,        pd.empl_rcd#
  ,        ba.acct_cd
  INTO     v_emplid
  ,        v_empl_rcd
  ,        v_acct_cd
  FROM     ps_personal_data    pd
  ,        ps_budget_actuals  ba
  WHERE    pd.emplid = ba.emplid
    AND    pd.empl_rcd# = ba.empl_rcd#
  ORDER BY pd.emplid
  ,        pd.empl_rcd#

/* Indentation Example 2: */
  BEGIN
    FOR  emp_rec IN c_empl
    LOOP
    IF emp_rec.empl_rcd# > 0 THEN
      ...
    END IF;
    END LOOP;
    RETURN v_exist;
  EXCEPTIONS
    WHEN OTHERS THEN
      RETURN FALSE;
  END;

/* Indentation Example 3: */
  FUNCTION GetEmplInfo ( p_empl_rcd  IN VARCHAR2
  ,                      p_emplid    IN VARCHAR2)
  ...

/* Cursors Example: */

FUNCTION GetEmplInfo ( p_empl_rcd  IN VARCHAR2
,                      p_emplid    IN VARCHAR2)
RETURN BOOLEAN IS
--
DECLARE 
  CURSOR c_empl IS
    SELECT  pd.emplid
    ,       pd.empl_rcd#
    FROM    ps_personal_data    pd
    WHERE   pd.emplid = p_emplid
      AND   pd.empl_rcd# = p_empl_rcd
      AND   pd.emplid = ba.emplid
      AND   pd.empl_rcd# = ba.empl_rcd#;
    Emp_rec c_empl%ROWTYPE;

  CURSOR c_budget (p_emplid    IN VARCHAR2
                   p_empl_rcd  IN VARCHAR2)
  IS
    SELECT  acct_cd
    FROM    ps_budget_actuals 
    WHERE   emplid = p_emplid
      AND   empl_rcd# = p_empl_rcd
    Budget_rec   c_budget%ROWTYPE;

/* Exception Handling Example: */

BEGIN
  FOR  emp_rec IN c_empl
  LOOP
    ...
  END LOOP;
  RETURN v_exist;
EXCEPTIONS
  WHEN NO_DATA_FOUND THEN
    RETURN FALSE;
  WHEN VALUE_ERROR THEN
    RETURN FALSE;
  WHEN OTHERS
    RETURN FALSE;
END;