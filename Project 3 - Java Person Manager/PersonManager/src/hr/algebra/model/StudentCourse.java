/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.model;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

/**
 *
 * @author arjan
 */
@Entity
@Table(name = "StudentCourse")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "StudentCourse.findAll", query = "SELECT s FROM StudentCourse s")
    , @NamedQuery(name = "StudentCourse.findById", query = "SELECT s FROM StudentCourse s WHERE s.id = :id")})
@OnDelete(action = OnDeleteAction.CASCADE)
public class StudentCourse implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "Id")
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    private Integer id;
    @JoinColumn(name = "CourseId", referencedColumnName = "Id")
    @ManyToOne(optional = false)
    private Course courseId;
    @JoinColumn(name = "StudentId", referencedColumnName = "Id")
    @ManyToOne(optional = false)
    private Student studentId;

    public StudentCourse() {
    }
    
    public StudentCourse(StudentCourse sc){
        updateDetails(sc);
    }

    public StudentCourse(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Course getCourseId() {
        return courseId;
    }

    public void setCourseId(Course courseId) {
        this.courseId = courseId;
    }

    public Student getStudentId() {
        return studentId;
    }

    public void setStudentId(Student studentId) {
        this.studentId = studentId;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof StudentCourse)) {
            return false;
        }
        StudentCourse other = (StudentCourse) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Course: " + courseId.getName() + ", student: " + studentId.getFirstName() + " " + studentId.getLastName();
    }
    
     public void updateDetails(StudentCourse data) {
        this.studentId = data.getStudentId();
        this.courseId = data.getCourseId();
    }
    
}
