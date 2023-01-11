/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao.sql;

import hr.algebra.dao.Repository;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author arjan
 */
public class HibernateFactory {

    

    private HibernateFactory() {
    }
    
    public static final String SELECT_STUDENTS = "Student.findAll";
    public static final String SELECT_COURSES = "Course.findAll";
    public static final String SELECT_PROFESSORS = "Professor.findAll";
    public static final String SELECT_STUDENT_COURSES = "StudentCourse.findAll";
    
    private static final String PERSISTENT_UNIT = "PersonManagerPU";
    
    private static final EntityManagerFactory EMF 
            = Persistence.createEntityManagerFactory(PERSISTENT_UNIT);
    
    public static EntityManagerWrapper getEntityManager() {
        return new EntityManagerWrapper(EMF.createEntityManager());
    }
      
    public static void release() {
        EMF.close();
    }
    
    
}
