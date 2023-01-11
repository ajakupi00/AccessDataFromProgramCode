/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao;



/**
 *
 * @author daniel.bele
 */
public interface Repository extends StudentRepository, CourseRepository, ProfessorRepository {
    
   
    default void release() throws Exception {}
}
