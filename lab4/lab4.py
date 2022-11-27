import numpy as np
n = 2
def f(x):
    def const(row):
        summ = 0
        for k in range(1, n+1):
            
            if (k == row+1):
                summ += k ** 3
            else:
                summ += k**2
        return summ
    arr = np.zeros(shape=(n))
    for i in range(0, n):
        for j in range(0, n):     
            if (i == j):
                arr[i] += x[j] ** 3
            else:
                arr[i] += x[j] ** 2
        arr[i] -= const(i)
    return arr
def df(x):
    arr = np.zeros(shape=(n,n))
    for i in range(0, n):
        for j in range(0, n):
            if (i == j):
                arr[i,j] = 3 * (x[j] ** 2)
            else:
                arr[i,j] = 2 * x[j]
    return arr
def g(x):
    arr = np.zeros(shape=(n))
    arr[0] = x[0]**2/(x[1]**2) - np.cos(x[1])-2
    arr[1] = x[0]**2 + x[1]**2-6
    return arr

def dg(x):
    arr = np.zeros(shape=(n,n))
    arr[0,0] = 2*x[0]/(x[1]**2)
    arr[0,1] = np.sin(x[1])-2*x[0]**2/(x[1]**3)
    arr[1,0] = 2 * x[0]
    arr[1,1] = 2 * x[1]
    return arr

def newtons_method(f, df, x0, e):
    iterations = 0
    delta = np.linalg.norm(np.dot(np.linalg.inv(df(x0)),f(x0)))
    while delta > e:
        x0 = x0 - np.dot(np.linalg.inv(df(x0)),f(x0))
        iterations+=1
        delta = np.linalg.norm(np.dot(np.linalg.inv(df(x0)),f(x0)))
    
    print('\nNewtons method:')
    print('x: ', x0)
    print('f(x): ', f(x0))
    print('Iterations: ', iterations)
def relaxation_method(f, df, x0, e):
    iterations = 0
    delta = np.linalg.norm(np.dot(np.linalg.inv(df(x0)),f(x0)))
    while delta > e:
        x0 = x0 - 0.2*f(x0)
        iterations+=1
        delta = np.linalg.norm(np.dot(np.linalg.inv(df(x0)),f(x0)))
    
    print('\nRelaxation method:')
    print('x: ', x0)
    print('f(x): ', f(x0))
    print('Iterations: ', iterations)
def mod_newtons_method(f, df, x, e):
    x0 = np.ones(n)
    delta = np.linalg.norm(np.dot(np.linalg.inv(df(x)),f(x)))
    iterations = 0
    matrix = np.linalg.inv(df(x0))
    while delta > e:
        x = x - np.dot(matrix,f(x))
        iterations+=1
        delta = np.linalg.norm(np.dot(np.linalg.inv(df(x)),f(x)))
    
    print('\nModified Newton\'s method:')
    print('x: ', x)
    print('f(x): ', f(x))
    print('Iterations: ', iterations)

relaxation_method(g, dg, np.array([1,1]), 10**-4)
newtons_method(g, dg, np.array([1,1]), 10**-4)
mod_newtons_method(g, dg, np.array([1,1]), 10**-4)

n = 5
newtons_method(f, df, np.array([1,1,1,1,1]), 10**-4)
