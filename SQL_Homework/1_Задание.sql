-- 1 Сотрудник с максимальной заработной платой.

SELECT NAME,SALARY 
FROM EMPLOYEE 
WHERE SALARY = (SELECT max(SALARY) from EMPLOYEE);

-- 2. Отдел, с самой высокой заработной платой между сотрудниками.

SELECT DEPARTMENT.NAME
FROM DEPARTMENT 
JOIN EMPLOYEE
ON DEPARTMENT.ID = EMPLOYEE.DEPARTMENT_ID
WHERE EMPLOYEE.SALARY  
IN 
 (SELECT MAX(EMPLOYEE.SALARY) FROM EMPLOYEE);

-- 3. Отдел, с максимальной суммарной зарплатой сотрудников. 

SELECT 
  SUM(Salary) AS MaxSumSalary,
  DEPARTMENT.ID AS DepartmentId, 
  DEPARTMENT.NAME AS DepartmentName
FROM EMPLOYEE
JOIN DEPARTMENT ON EMPLOYEE1.DEPARTMENT_ID = DEPARTMENT.ID
GROUP BY DEPARTMENT.ID , DEPARTMENT.NAME
ORDER BY MaxSumSalary DESC
LIMIT 1;

-- 4. Сотрудника, чье имя начинается на «Р» и заканчивается на «н».
SELECT NAME
FROM EMPLOYEE
WHERE NAME LIKE 'Р%н';

